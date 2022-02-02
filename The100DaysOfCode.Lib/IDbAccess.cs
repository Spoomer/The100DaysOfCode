using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The100DaysOfCode.Lib;

public interface IDbAccess
{
    IEnumerable<T> GetManyAsEnumerable<T>() where T : class, IDbObject;
    IList<T> GetManyAsList<T>() where T : class, IDbObject;
    //IEnumerable<T> GetList<T>(string fieldname, string fieldvalue) where T : class, IDbObject;
    IAsyncEnumerable<T> GetManyAsAsyncEnumerable<T>() where T : class, IDbObject;
    Task<IList<T>> GetManyAsListAsync<T>() where T : class, IDbObject;
    //Task<IEnumerable<T>> GetListAsync<T>(string fieldname, string fieldvalue) where T : class, IDbObject;
    T? GetWithId<T> (int id) where T : class, IDbObject;
    Task<T?> GetWithIdAsync<T> (int id) where T : class, IDbObject;
    T? Get<T> (string fieldname, string fieldvalue) where T : class, IDbObject;
    Task<T?> GetAsync<T> (string fieldname, string fieldvalue) where T : class, IDbObject;
    void Create<T> (T obj) where T : class, IDbObject;
    Task CreateAsync<T> (T obj) where T : class, IDbObject;
    bool Replace<T> (T obj) where T : class, IDbObject;
    Task<bool> ReplaceAsync<T> (T obj) where T : class, IDbObject;
    void Delete<T> (int id) where T : class, IDbObject;
    Task DeleteAsync<T> (int id) where T : class, IDbObject;
    IQueryable GetQueryable<T>() where T : class, IDbObject;

}
