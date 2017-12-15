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

        public string VariantOf
        {
            get { return data.variant_of; }
            set { data.variant_of = value; }
        }

        public string Barcode
        {
            get { return data.barcode; }
            set { data.barcode = value; }
        }

        public string UnitOfMeasure
        {
            get { return data.stock_uom; }
            set { data.stock_uom = value; }
        }

        public string Description
        {
            get { return data.description; }
            set { data.description = value; }
        }

        public string DefaultWarehouse
        {
            get { return data.default_warehouse; }
            set { data.default_warehouse = value; }
        }

        public string DefaultSupplier
        {
            get { return data.default_supplier; }
            set { data.default_supplier = value; }
        }

        #region iGLOi specific variables
        public string CustomerItemName
        {
            get { return data.customer_item_name; }
            set { data.customer_item_name = value; }
        }
        #endregion
        #endregion
    }
}