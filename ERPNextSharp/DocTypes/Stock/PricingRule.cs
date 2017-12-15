using ERPNextSharp.Data;

namespace ERPNextSharp.DocTypes.Stock
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/stock/item
    /// </summary>
    public class PricingRule : ERPNextObjectBase
    {
        #region constructor
        public PricingRule() : this(new ERPObject(DocType.PricingRule))
        {
        }

        public PricingRule(ERPObject obj) : base(obj)
        {
        }
        #endregion

        #region variable access
        public string Title
        {
            get { return data.title; }
            set { data.title = value; }
        }

        public string ItemCode
        {
            get { return data.item_code; }
            set { data.item_code = value; }
        }

        public string Selling
        {
            get { return data.selling; }
            set { data.selling = value; }
        }

        public string Buying
        {
            get { return data.buying; }
            set { data.buying = value; }
        }

        public string MinQTY
        {
            get { return data.min_qty; }
            set { data.min_qty = value; }
        }

        public string MaxQTY
        {
            get { return data.max_qty; }
            set { data.max_qty = value; }
        }

        public string PriceOrDiscount
        {
            get { return data.price_or_discount; }
            set { data.price_or_discount = value; }
        }

        public string Price
        {
            get { return data.price; }
            set { data.price = value; }
        }

        #endregion
    }
}