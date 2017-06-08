using ERPNext.DocTypes.Customer;
using ERPNextSharp.Data;
using ERPNextSharp.Service;

namespace ERPNextSharp.DocTypes.Customer
{
    public class CustomerService : SubServiceBase<ERPCustomer>
    {
        public CustomerService(ERPNextClient client) 
            : base(DocType.Customer, client) { }

        protected override ERPCustomer fromERPObject(ERPObject obj)
        {
            return new ERPCustomer(obj);
        }
    }
}