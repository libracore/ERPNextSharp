using ERPNextSharp.Data;
using System;

namespace ERPNextSharp.DocTypes.Setup
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/setup/party_type
    /// </summary>
    public class PartyType : ERPNextObjectBase
    { 
        #region constructor
        public PartyType() 
            : this(new ERPObject(DocType.Account))
        { }

        public PartyType(ERPObject obj) 
            : base(obj)
        { }

        #endregion

        #region variable access
        /// <summary>
        /// Party type name
        /// </summary>
        public string PartyTypeName
        {
            get { return data.party_type; }
            set { data.party_type = value; }
        }
        #endregion
    }
}