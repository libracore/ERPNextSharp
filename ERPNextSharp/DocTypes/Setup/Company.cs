using ERPNextSharp.Data;
using System;

namespace ERPNextSharp.DocTypes.Setup
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/setup/company
    /// </summary>
    public class Company : ERPNextObjectBase
    { 
        #region constructor
        public Company() 
            : this(new ERPObject(DocType.Account))
        { }

        public Company(ERPObject obj) 
            : base(obj)
        { }

        #endregion

        #region variable access
        /// <summary>
        /// Company name
        /// </summary>
        public string CompanyName
        {
            get { return data.company_name; }
            set { data.company_name = value; }
        }

        /// <summary>
        /// Company abbreviation
        /// </summary>
        public string Abbreviation
        {
            get { return data.abbr; }
            set { data.abbr = value; }
        }

        /// <summary>
        /// Company country
        /// </summary>
        public string Country
        {
            get { return data.country; }
            set { data.country = value; }
        }

        /// <summary>
        /// Default currency
        /// </summary>
        public string DefaultCurrency
        {
            get { return data.default_currency; }
            set { data.default_currency = value; }
        }
        #endregion
    }
}