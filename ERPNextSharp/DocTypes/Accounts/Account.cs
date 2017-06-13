using ERPNextSharp.Data;
using System;

namespace ERPNext.DocTypes.Accounts
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/accounts/account
    /// </summary>
    public class Account : ERPNextObjectBase
    { 
        #region constructor
        public Account() 
            : this(new ERPObject(DocType.Account))
        { }

        public Account(ERPObject obj) 
            : base(obj)
        { }

        #endregion

        #region variable access
        /// <summary>
        /// Account name
        /// </summary>
        public string AccountName
        {
            get { return data.account_name; }
            set { data.account_name = value; }
        }

        /// <summary>
        /// Company (booking entity)
        /// </summary>
        public string Company
        {
            get { return data.company; }
            set { data.company = value; }
        }

        /// <summary>
        /// Parent account
        /// </summary>
        public string ParentAccount
        {
            get { return data.parent_account; }
            set { data.parent_account = value; }
        }

        public AccountTypes AccountType
        {
            get { return parseEnum<AccountTypes>(data.root_type); }
            set { data.root_type = value.ToString(); }
        }
        #endregion
    }

    public enum AccountTypes
    {
        None,
        Asset,
        Liability,
        Income,
        Expense,
        Equity,
    }
}