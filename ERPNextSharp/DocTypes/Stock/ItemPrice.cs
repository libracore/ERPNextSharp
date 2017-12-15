using ERPNextSharp.Data;

namespace ERPNextSharp.DocTypes.Stock
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/stock/item
    /// </summary>
    public class ItemPrice : ERPNextObjectBase
    {
        #region constructor
        public ItemPrice() : this(new ERPObject(DocType.ItemPrice))
        {
        }

        public ItemPrice(ERPObject obj) : base(obj)
        {
        }
        #endregion

        #region variable access
        public string PriceList
        {
            get { return data.price_list; }
            set { data.price_list = value; }
        }

        public string ItemCode
        {
            get { return data.item_code; }
            set { data.item_code = value; }
        }

        public string Rate
        {
            get { return data.price_list_rate; }
            set { data.price_list_rate = value; }
        }

        #endregion
    }
}