using ERPNextSharp.Data;
using System.Collections.Generic;

namespace ERPNextSharp.DocTypes.Stock
{
    /// <summary>
    /// Reference: https://frappe.github.io/erpnext/current/models/stock/item
    /// </summary>
    public class ItemSupplier : ERPNextObjectBase
    {
        #region constructor
        public ItemSupplier() : this(new ERPObject(DocType.ItemSupplier))
        {
        }

        public ItemSupplier(ERPObject obj) : base(obj)
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
        public string supplier
        {
            get { return data.supplier; }
            set { data.supplier = value; }
        }
        public string supplier_part_no
        {
            get { return data.supplier_part_no; }
            set { data.supplier_part_no = value; }
        }
        public string parent
        {
            get { return data.parent; }
            set { data.parent = value; }
        }
        public string parentfield
        {
            get { return data.parentfield; }
            set { data.parentfield = value; }
        }
        public string parenttype
        {
            get { return data.parenttype; }
            set { data.parenttype = value; }
        }

        #endregion
    }
}