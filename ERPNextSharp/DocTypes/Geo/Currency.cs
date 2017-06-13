using ERPNextSharp.Data;
using System;

namespace ERPNext.DocTypes.Geo
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/accounts/payment_entry
    /// </summary>
    public class Currency : ERPNextObjectBase
    { 
        #region constructor
        public Currency() 
            : this(new ERPObject(DocType.Account))
        { }

        public Currency(ERPObject obj) 
            : base(obj)
        { }

        #endregion

        #region variable access
        /// <summary>
        /// Currency name
        /// </summary>
        public string CurrencyName
        {
            get { return data.currency_name; }
            set { data.currency_name = value; }
        }
        #endregion
    }
}