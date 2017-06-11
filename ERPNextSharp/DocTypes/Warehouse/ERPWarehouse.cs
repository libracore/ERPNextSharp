using ERPNextSharp.Data;
using ERPNextSharp.DocTypes.Item;

namespace ERPNextSharp.DocTypes.Warehouse
{
    public class ERPWarehouse : ERPNextObjectBase
    {
        #region constructor
        public ERPWarehouse() : this(new ERPObject(DocType.Item))
        {
        }

        public ERPWarehouse(ERPObject obj) : base(obj)
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
