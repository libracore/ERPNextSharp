using ERPNextSharp.Data;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Items sub-table
        /// </summary>
        public StockEntryDetail[] Items
        {
            get
            {
                List<StockEntryDetail> items = new List<StockEntryDetail>();
                for (int i = 0; i < data.items.Count; i++)
                {
                    items.Add(new StockEntryDetail(data.items[i]));

                }
                return items.ToArray();
            }
            set
            {
                data.items = new IDictionary<string, object>[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    data.items[i] = value[i].GetDictionary();
                }
            }
        }

        public Purposes Purpose
        {
            get
            {
                Purposes p = Purposes.Manufacture;
                switch (data.purpose)
                {
                    case "Material Issue": p = Purposes.MaterialIssue; break;
                    case "Material Receipt": p = Purposes.MaterialReceipt; break;
                    case "Material Transfer": p = Purposes.MaterialTransfer; break;
                    case "Material Transfer for Manufacture": p = Purposes.MaterialTransferForManufacture; break;
                    case "Manufacture": p = Purposes.Manufacture; break;
                    case "Repack": p = Purposes.Repack; break;
                    case "Subcontract": p = Purposes.Subcontract; break;
                }
                return p;
            }
            set
            {
                switch (value)
                {
                    case Purposes.MaterialIssue: data.purpose = "Material Issue"; break;
                    case Purposes.MaterialReceipt: data.purpose = "Material Receipt"; break;
                    case Purposes.MaterialTransfer: data.purpose = "Material Transfer"; break;
                    case Purposes.MaterialTransferForManufacture: data.purpose = "Material Transfer for Manufacture"; break;
                    case Purposes.Manufacture: data.purpose = "Manufacture"; break;
                    case Purposes.Repack: data.purpose = "Repack"; break;
                    case Purposes.Subcontract: data.purpose = "Subcontract"; break;
                }
            }
        }
        #endregion
    }

    #region payment data types
    public enum Purposes
    {
        MaterialIssue,
        MaterialReceipt,
        MaterialTransfer,
        MaterialTransferForManufacture,
        Manufacture,
        Repack,
        Subcontract
    }
    #endregion
}