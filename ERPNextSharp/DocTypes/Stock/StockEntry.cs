using ERPNextSharp.Data;
using System;

namespace ERPNextSharp.DocTypes.Stock
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/stock/stock_entry
    /// </summary>
    public class StockEntry : ERPNextObjectBase
    { 
        #region constructor
        public StockEntry() 
            : this(new ERPObject(DocType.Currency))
        { }

        public StockEntry(ERPObject obj) 
            : base(obj)
        { }

        #endregion

        #region variable access
        /// <summary>
        /// Source warehouse
        /// </summary>
        public string FromWarehouse
        {
            get { return data.from_warehouse; }
            set { data.from_warehouse = value; }
        }

        /// <summary>
        /// Destination warehouse
        /// </summary>
        public string ToWarehouse
        {
            get { return data.to_warehouse; }
            set { data.to_warehouse = value; }
        }
        #endregion
    }
}