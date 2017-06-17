using ERPNextSharp.Data;
using System;
using System.Collections.Generic;

namespace ERPNextSharp.DocTypes.Stock
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/stock/stock_entry_detail
    /// </summary>
    public class StockEntryDetail : ERPNextObjectBase
    { 
        #region constructor
        public StockEntryDetail() 
            : this(new ERPObject(DocType.Currency))
        { }

        public StockEntryDetail(ERPObject obj) 
            : base(obj)
        { }

        #endregion

        #region JSON serializer
        public IDictionary<string, object> GetDictionary()
        {
            // cast to an IDictionary<string, object>
            IDictionary<string, object> dict = data;

            return dict;
        }
        #endregion

        #region variable access
        /// <summary>
        /// Item code (links to Item)
        /// </summary>
        public string ItemCode
        {
            get { return data.item_code; }
            set { data.item_code = value; }
        }

        /// <summary>
        /// Item name (retrieved from item)
        /// </summary>
        public string ItemName
        {
            get { return data.item_name; }
            set { data.item_name = value; }
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get { return data.description; }
            set { data.description = value; }
        }

        /// <summary>
        /// Quantity
        /// </summary>
        public double Quantity
        {
            get { return data.qty; }
            set { data.qty = value; }
        }

        /// <summary>
        /// Batch number (links to Batch)
        /// </summary>
        public string BatchNo
        {
            get { return data.batch_no; }
            set { data.batch_no = value; }
        }

        /// <summary>
        /// Serial number
        /// </summary>
        public string SerialNo
        {
            get { return data.serial_no; }
            set { data.serial_no = value; }
        }
        #endregion
    }
}