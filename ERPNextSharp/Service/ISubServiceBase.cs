using System.Collections.Generic;
using ERPNextSharp.Data;

namespace ERPNextSharp.Service
{
    public interface ISubServiceBase<T> where T : ERPNextObjectBase
    {
        DocType ObjectType { get; }
        T Create(T obj);
        T Get(string name);
        List<string> ListNames(List<ERPFilter> filters, int pageSize = 0, int pageStartIndex = 0);
        List<ERPObject> ListObjects(FetchListOption listOption);
        void Update(T obj);
        void Delete(string name);
    }
}
