using ERPNextSharp.Data;
using ERPNextSharp.DocTypes.Item;

namespace ERPNextSharp.DocTypes.Warehouse
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/stock/warehouse
    /// </summary>
    public class Warehouse : ERPNextObjectBase
    {
        #region constructor
        public Warehouse() : this(new ERPObject(DocType.Item))
        {
        }

        public Warehouse(ERPObject obj) : base(obj)
        {
        }
        #endregion

        #region varîable access
        public string ParentWarehouse
        {
            get { return data.parent_warehouse; }
            set { data.parent_warehouse = value; }
        }

        public string WarehouseName
        {
            get { return data.warehouse_name; }
            set { data.warehouse_name = value; }
        }

        public string Company
        {
            get { return data.company; }
            set { data.company = value; }
        }
        #endregion
    }
}
