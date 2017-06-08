using ERPNextSharp.Data;
using ERPNextSharp.Service;
using System.Collections.Generic;
using System.Linq;

namespace ERPNextSharp.DocTypes.Warehouse
{
    public class WarehouseService : SubServiceBase<ERPWarehouse>
    {
        public WarehouseService(ERPNextClient client) : base(DocType.Warehouse, client)
        {
        }

        public List<ERPWarehouse> GetRootWarehouses()
        {
            FetchListOption listOption = new FetchListOption();
            listOption.Filters.Add(new ERPFilter(DocType.Warehouse, "parent_warehouse", OperatorFilter.Equals, ""));
            List<ERPObject> warehouses_list = client.ListObjects(DocType.Warehouse, listOption);
            return warehouses_list.Select(x => new ERPWarehouse(x)).ToList();
        }

        protected override ERPWarehouse fromERPObject(ERPObject obj)
        {
            return new ERPWarehouse(obj);
        }
    }
}