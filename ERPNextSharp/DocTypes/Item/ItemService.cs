using ERPNextSharp.Data;
using ERPNextSharp.Service;

namespace ERPNextSharp.DocTypes.Item
{
    public class ItemService : SubServiceBase<ERPItem>
    {
        public ItemService(ERPNextClient client) : base(DocType.Item, client)
        {
        }

        protected override ERPItem fromERPObject(ERPObject obj)
        {
            return new ERPItem(obj);
        }
    }
}