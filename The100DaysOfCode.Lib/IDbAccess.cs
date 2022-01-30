using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The100DaysOfCode.Lib;

public interface IDbAccess
{
    IEnumerable<T> GetList<T>() where T : IDbObject;
    Task<IEnumerable<T>> GetListAsync<T>() where T : class, IDbObject;
    T GetWithId<T> (int id) where T : IDbObject;
    Task<T> GetWithIdAsync<T> (int id) where T : IDbObject;
    T Get<T> (string fieldname, string fieldvalue) where T : IDbObject;
    T GetAsync<T> (string fieldname, string fieldvalue) where T : IDbObject;
    T Create<T> (T obj) where T : IDbObject;
    Task<T> CreateAsync<T> (T obj) where T : IDbObject;
    T Replace<T> (T obj) where T : IDbObject;
    Task<T> ReplaceAsync<T> (T obj) where T : IDbObject;
    T Delete<T> (T obj) where T : IDbObject;
    Task<T> DeleteAsync<T> (T obj) where T : IDbObject;

}
