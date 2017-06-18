using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Reflection;
using ERPNextSharp.Data;

namespace ERPNextSharp
{
    public class ERPNextClient : IDisposable
    {
        #region global variables
        /// <summary>
        /// ERPNext host name
        /// </summary>  
        private string host;
        /// <summary>
        /// ERPNext login user name
        /// </summary>
        private string username;
        /// <summary>
        /// ERPNext login password
        /// </summary>
        private string password;
        /// <summary>
        /// RestSharp instance to use
        /// </summary>
        private RestClient client;

        #region event preparation
        /* event delegate declaration */
        public delegate void ErrorEvent(string message);

        /* event definition */
        public event ErrorEvent HasError;

        #endregion
        #endregion

        #region constructor
        /// <summary>
        /// Creates a new ERPNext client
        /// </summary>
        /// <param name="host">ERPNext host name</param>
        public ERPNextClient(string host)
        {
            this.host = host;
            client = new RestClient(host);
            client.CookieContainer = new CookieContainer();
        }

        /// <summary>
        /// Creates a new ERPNext client
        /// </summary>
        /// <param name="host">ERPNext host name</param>
        /// <param name="username">ERPNext user name</param>
        /// <param name="password">ERPNExt password</param>
        public ERPNextClient(string host, string username, string password) : this(host)
        {
            Login(username, password);
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Dispose instance
        /// </summary>
        public void Dispose()
        {
            host = null;
            username = null;
            password = null;
            client.ClearHandlers();
            client.CookieContainer = null;
        }
        #endregion

        #region authentication control
        public void Login(string username, string password)
        {
            this.username = username;
            this.password = password;
            client.CookieContainer = new CookieContainer();

            loginIfNeeded();
        }

        private void loginIfNeeded()
        {
            if (!IsLoggedIn)
            {
                doLogin();
            }
        }

        private void doLogin()
        {
            if (string.IsNullOrEmpty(username)) return;
            if (string.IsNullOrEmpty(password)) return;

            var data = RPC("login", Method.POST, new { usr = username, pwd = password }, false);
        }

        /// <summary>
        /// Returns the login state (true = logged in)
        /// </summary>
        public bool IsLoggedIn
        {
            get
            {
                try
                {
                    CookieCollection collection = client.CookieContainer.GetCookies(new Uri(host));
                    Cookie session_cookie = collection["sid"];
                    if (session_cookie != null)
                    {
                        bool is_cookie_active = DateTime.Now < session_cookie.Expires;
                        return is_cookie_active;
                    }
                }
                catch
                {
                    return false;
                }
                return false;
            }
        }

        public string GetActiveUserName()
        {
            dynamic data = RPC("frappe.auth.get_logged_user", Method.GET);
            return data.message;
        }
        #endregion

        #region API calls
        public dynamic RPC(string targetMethod, Method method, dynamic args = null, bool ensureLoggedIn = true)
        {
            if (ensureLoggedIn)
            {
                loginIfNeeded();
            }

            IRestRequest request = new RestRequest($"/api/method/{targetMethod}", method);

            args = args ?? new { };
            Type args_type = args.GetType();
            var valid_props = args_type.GetProperties();

            foreach (PropertyInfo prop in valid_props)
            {
                var val = prop.GetValue(args);
                request.AddParameter(prop.Name, val);
            }

            var response = client.Execute(request);
            assertResponseIsOK(response);

            return parseDynamic(response);
        }

        private bool assertResponseIsOK(IRestResponse response)
        {
            bool ok = false;
            try
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                    case HttpStatusCode.Accepted:
                        ok = true;
                        break;
                    default:
                        OnHasError(string.Format("ErrorCode: {0}\r\nDescription:\r\n{1}\r\nReason:\r\n{2}\r\n",
                            response.StatusCode.ToString(), response.StatusDescription, response.Content)); 
                        ok = false;
                        break;
                }
            }
            catch (Exception err)
            {
                ok = false;
                OnHasError(err.Message);
            }
            return ok;
        }

        private ExpandoObject parseDynamic(IRestResponse response)
        {
            ExpandoObject obj = new ExpandoObject();
            try
            {
                JsonDeserializer des = new JsonDeserializer();
                Dictionary<string, object> result = des.Deserialize<Dictionary<string, object>>(response);

                obj = convertToData(result);
            }
            catch (Exception err)
            {
                OnHasError(err.Message);
                obj = null;
            }
            return obj;
        }

        /// <summary>
        /// Returns one single object
        /// </summary>
        /// <param name="docType">DocType</param>
        /// <param name="response">Response argument</param>
        /// <returns>An ERPObject</returns>
        private ERPObject parseOneObject(DocType docType, IRestResponse response)
        {
            ERPObject obj = new ERPObject(docType);
            try
            {
                JsonDeserializer des = new JsonDeserializer();
                DocRaw data_json = des.Deserialize<DocRaw>(response);

                obj = new ERPObject(docType, convertToData(data_json.data));
            }
            catch (Exception err)
            {
                OnHasError(err.Message);
                obj = null;
            }
            return obj;
        }

        /// <summary>
        /// Returns a list of objects
        /// </summary>
        /// <param name="docType">DocType</param>
        /// <param name="response">Response argument</param>
        /// <returns>A list of ERPObjects</returns>
        private List<ERPObject> parseManyObjects(DocType docType, IRestResponse response)
        {
            List<ERPObject> objects = new List<ERPObject>();
            try
            {
                JsonDeserializer des = new JsonDeserializer();
                DocRawList data_json = des.Deserialize<DocRawList>(response);

                objects = data_json.data.Select(x => new ERPObject(docType, convertToData(x))).ToList();
            }
            catch (Exception err)
            {
                OnHasError(err.Message);
                objects = null;
            }
            return objects;
        }

        private static ExpandoObject convertToData(IDictionary<string, object> vals)
        {
            ExpandoObject result = new ExpandoObject();

            var iface = (IDictionary<string, object>)result;

            foreach (var pair in vals)
            {
                object value = pair.Value;
                if (value is IDictionary<string, object>)
                {
                    value = convertToData((IDictionary<string, object>)value);
                }

                iface[pair.Key] = value;
            }

            return result;
        }

        private static List<string> toFilterObject(ERPFilter filter)
        {
            List<string> result = new List<string>();
            result.Add(filter.DocType.ToString());
            result.Add(filter.TargetField);
            result.Add(OperatorFilterUtils.ToString(filter.OperatorFilter));
            result.Add(filter.Operand);
            return result;
        }
        #endregion

        #region access functions
        public ERPObject InsertObject(ERPObject obj)
        {
            loginIfNeeded();

            RestRequest request = new RestRequest($"/api/resource/{obj.ObjectType}", Method.POST);

            var args_text = ToString(obj.Data);
            request.AddParameter("data", args_text);

            var response = this.client.Execute(request);

            ERPObject output = obj;
            if (assertResponseIsOK(response))
            {
                output = parseOneObject(obj.ObjectType, response);
            }

            return obj;
        }

        public ERPObject GetObject(DocType docType, string name)
        {
            loginIfNeeded();

            RestRequest request = new RestRequest($"/api/resource/{docType}/{name}", Method.GET);

            var response = this.client.Execute(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            ERPObject output = new ERPObject(docType);
            if (assertResponseIsOK(response))
            {
                output = parseOneObject(docType, response);
            }

            return output;
        }

        public ERPObject UpdateObject(ERPObject obj)
        {
            return UpdateObject(obj.ObjectType, obj.Name, obj);
        }

        public ERPObject UpdateObject(DocType docType, string name, ERPObject obj)
        {
            loginIfNeeded();

            RestRequest request = new RestRequest($"/api/resource/{docType}/{name}", Method.PUT);
            var args_text = ToString(obj.Data);
            request.AddParameter("data", args_text);

            var response = this.client.Execute(request);

            ERPObject output = obj;
            if (assertResponseIsOK(response))
            { 
                output = parseOneObject(docType, response);
            }

            return output;
        }

        public void DeleteObject(DocType docType, string name)
        {
            loginIfNeeded();

            RestRequest request = new RestRequest($"/api/resource/{docType}/{name}", Method.DELETE);

            var response = this.client.Execute(request);

            assertResponseIsOK(response);
        }

        public List<ERPObject> ListObjects(DocType docType, FetchListOption listOption = null)
        {
            loginIfNeeded();

            listOption = listOption ?? new FetchListOption();
            RestRequest request = new RestRequest($"/api/resource/{docType}", Method.GET);

            var filters = listOption.Filters ?? new List<ERPFilter>();
            if (filters.Any())
            {
                var filter_val = ToString(filters.Select(toFilterObject).ToList());
                request.AddParameter("filters", filter_val);
            }

            var included_fields = listOption.IncludedFields ?? new List<string>();
            if (included_fields.Any())
            {
                var filter_val = ToString(included_fields.ToList());
                request.AddParameter("fields", filter_val);
            }

            if (listOption.PageSize > 0)
            {
                request.AddParameter("limit_page_length", listOption.PageSize);
            }

            if (listOption.PageStartIndex > 0)
            {
                request.AddParameter("limit_start", listOption.PageStartIndex);
            }

            var response = this.client.Execute(request);
            List<ERPObject> objects = new List<ERPObject>();
            if (assertResponseIsOK(response))
            {
                objects = parseManyObjects(docType, response);
            }

            return objects;
        }
        #endregion

        #region support functions
        public static string ToString(object obj)
        {
            JsonSerializer s = new JsonSerializer();
            return s.Serialize(obj);
        }
        #endregion

        #region event handlers
        protected void OnHasError(string message)
        {
            // Check if there are any Subscribers
            // Call the Event
            HasError?.Invoke(message);
        }
        #endregion
    }
}
