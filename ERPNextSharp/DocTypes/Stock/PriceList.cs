using ERPNextSharp.Data;

namespace ERPNextSharp.DocTypes.Stock
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/stock/item
    /// </summary>
    public class PriceList : ERPNextObjectBase
    {
        #region constructor
        public PriceList() : this(new ERPObject(DocType.PriceList))
        {
        }

        public PriceList(ERPObject obj) : base(obj)
        {
        }
        #endregion

        #region variable access
        public string PriceListName
        {
            get { return data.price_list_name; }
            set { data.price_list_name = value; }
        }
        public string Currency
        {
            get { return data.currency; }
            set { data.currency = value; }
        }

        #endregion
    }
}