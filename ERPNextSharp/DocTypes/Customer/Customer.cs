using ERPNextSharp.Data;

namespace ERPNextSharp.DocTypes.Customer
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/selling/customer
    /// </summary>
    public class Customer : ERPNextObjectBase
    { 
        #region constructor
        public Customer() : this(new ERPObject(DocType.Customer))
        { }

        public Customer(ERPObject obj) : base(obj)
        { }
        #endregion

        #region variable access
        public CustomerTypes CustomerType
        {
            get { return parseEnum<CustomerTypes>(data.customer_type); }
            set { data.customer_type = value.ToString(); }
        }

        public string CustomerName
        {
            get { return data.customer_name; }
            set
            {
                data.customer_name = value;
                data.name = value;
            }
        }

        public string CustomerGroup
        {
            get { return data.customer_group; }
            set { data.customer_group = value; }
        }

        public string Website
        {
            get
            {
                string website = string.Empty;
                try
                {
                    website = data.website;
                }
                catch { }
                return website;
            }
            set { data.website = value; }
        }

        public string Territory
        {
            get { return data.territory; }
            set { data.territory = value; }
        }

        public string Owner
        {
            get { return data.owner; }
            set { data.owner = value; }
        }

        public CustomerStatuses Status
        {
            get
            {
                CustomerStatuses s = CustomerStatuses.None;
                try
                {
                    s = parseEnum<CustomerStatuses>(data.status);
                }
                catch
                {
                    s = CustomerStatuses.None;
                }
                return s;
            }
            set { data.status = value.ToString(); }
        }
        #endregion
    }

    #region customer data types
    public enum CustomerTypes
    {
        Company,
        Individual,
    }

    public enum CustomerStatuses
    {
        Active,
        Dormant,
        Open,
        None
    }
    #endregion
}