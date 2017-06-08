using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNextSharp.Data
{
    public sealed class ERPObject
    {
        public DocType ObjectType { get; private set; }
        private ExpandoObject data;

        public ERPObject(DocType objectType)
            : this(objectType, new ExpandoObject()) { }

        public ERPObject(DocType objectType, ExpandoObject data)
        {
            this.ObjectType = objectType;
            this.data = data ?? new ExpandoObject();
        }

        public dynamic Data
        {
            get { return data; }
            set { data = value; }
        }

        public string Name
        {
            get { return Data.name; }
            set { Data.name = value; }
        }

        public bool TryGetValue(string propertyName, out object val)
        {
            var dict = (IDictionary<string, object>)data;
            return dict.TryGetValue(propertyName, out val);
        }

        public object GetValue(string propertyName)
        {
            var dict = (IDictionary<string, object>)data;
            return dict[propertyName];
        }

        public ERPObject Clone()
        {
            ERPObject result = (ERPObject)MemberwiseClone();
            result.data = CloneObject(data);

            return result;
        }

        #region support functions
        public static ExpandoObject CloneObject(ExpandoObject source)
        {
            ExpandoObject target = new ExpandoObject();
            var target_iface = (IDictionary<string, object>)target;
            foreach (var kvp in (IDictionary<string, object>)source)
            {
                target_iface.Add(kvp);
            }

            return target;
        }
        #endregion
    }
}
