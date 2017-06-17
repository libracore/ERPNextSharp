using ERPNextSharp.Data;

namespace ERPNextSharp.DocTypes.Stock
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/stock/item
    /// </summary>
    public class Item : ERPNextObjectBase
    {
        #region constructor
        public Item() : this(new ERPObject(DocType.Item))
        {
        }

        public Item(ERPObject obj) : base(obj)
        {
        }
        #endregion

        #region variable access
        public string ItemCode
        {
            get { return data.item_code; }
            set { data.item_code = value; }
        }

        public string ItemName
        {
            get { return data.item_name; }
            set { data.item_name = value; }
        }

        public string ItemGroup
        {
            get { return data.item_group; }
            set { data.item_group = value; }
        }

        public double TotalProjectedQty
        {
            get { return data.total_projected_qty; }
            set { data.total_projected_qty = value; }
        }

        public double LastPurchaseRate
        {
            get { return data.last_purchase_rate; }
            set { data.last_purchase_rate = value; }
        }
        #endregion
    }
}