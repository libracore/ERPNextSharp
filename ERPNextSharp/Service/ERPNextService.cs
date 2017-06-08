using ERPNextSharp.DocTypes.Customer;
using ERPNextSharp.DocTypes.Item;
using ERPNextSharp.DocTypes.Warehouse;

namespace ERPNextSharp.Service
{
    public class ERPNextServices
    {
        public ERPNextClient Client { get; }
        public CustomerService CustomerService { get; }
        public ItemService ItemService { get; }
        public WarehouseService WarehouseService { get; }

        public ERPNextServices(string domain, string username, string password)
        {
            this.Client = new ERPNextClient(domain, username, password);
            this.CustomerService = new CustomerService(Client);
            this.ItemService = new ItemService(Client);
            this.WarehouseService = new WarehouseService(Client);
        }
    }
}
