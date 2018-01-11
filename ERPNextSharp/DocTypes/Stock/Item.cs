using ERPNextSharp.Data;
using System.Collections.Generic;
using System.Linq;

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
        #region JSON serializer
        public IDictionary<string, object> GetDictionary()
        {
            // cast to an IDictionary<string, object>
            IDictionary<string, object> dict = data;

            return dict;
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

        public string DefaultMaterialRequestType
        {
            get { return data.default_material_request_type; }
            set { data.default_material_request_type = value; }
        }

        public string has_batch_no
        {
            get { return data.has_batch_no; }
            set { data.has_batch_no = value; }
        }

        public string create_new_batch
        {
            get { return data.create_new_batch; }
            set { data.create_new_batch = value; }
        }

        public string has_expiry_date
        {
            get { return data.has_expiry_date; }
            set { data.has_expiry_date = value; }
        }

        public string publish_in_hub
        {
            get { return data.publish_in_hub; }
            set { data.publish_in_hub = value; }
        }

        public string is_stock_item
        {
            get { return data.is_stock_item; }
            set { data.is_stock_item = value; }
        }

        public ItemSupplier[] Supplier_items
        {
            get
            {
                List<ItemSupplier> Supplier_items = new List<ItemSupplier>();
                for (int i = 0; i < data.items.Count; i++)
                {
                    Supplier_items.Add(new ItemSupplier(data.Supplier_items[i]));

                }
                return Supplier_items.ToArray();
            }
            set
            {
                data.Supplier_items = new IDictionary<string, object>[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    data.Supplier_items[i] = value[i].GetDictionary();
                }
            }
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