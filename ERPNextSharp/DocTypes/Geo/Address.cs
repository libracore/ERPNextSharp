using ERPNextSharp.Data;
using System;

namespace ERPNextSharp.DocTypes.Geo
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/geo/address
    /// </summary>
    public class Address : ERPNextObjectBase
    { 
        #region constructor
        public Address() 
            : this(new ERPObject(DocType.Currency))
        { }

        public Address(ERPObject obj) 
            : base(obj)
        { }

        #endregion

        #region variable access
        /// <summary>
        /// Currency name
        /// </summary>
        public string AddressName
        {
            get { return data.currency_name; }
            set { data.currency_name = value; }
        }
        #endregion
    }
}