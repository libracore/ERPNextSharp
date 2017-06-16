using ERPNextSharp.Data;
using System;

namespace ERPNext.DocTypes.Accounts
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/accounts/sales_invoice
    /// </summary>
    public class SalesInvoice : ERPNextObjectBase
    { 
        #region constructor
        public SalesInvoice() 
            : this(new ERPObject(DocType.SalesInvoice))
        { }

        public SalesInvoice(ERPObject obj) 
            : base(obj)
        { }

        #endregion

        #region variable access
        /// <summary>
        /// Currency name
        /// </summary>
        public string SaleInvoiceName
        {
            get { return data.currency_name; }
            set { data.currency_name = value; }
        }

        /// <summary>
        /// Related customer
        /// </summary>
        public string Customer
        {
            get { return data.customer; }
            set { data.custmomer = value; }
        }
        #endregion
    }
}