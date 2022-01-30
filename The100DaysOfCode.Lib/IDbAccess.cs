using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The100DaysOfCode.Lib;

public interface IDbAccess
{
    T GetWithId<T> (int id) where T : IDbObject;
    Task<T> GetWithIdAsync<T> (int id) where T : IDbObject;
    T Get<T> (string fieldname, string fieldvalue);
    T GetAsync<T> (string fieldname, string fieldvalue);
    T Create<T> (T obj);
    Task<T> CreateAsync<T> (T obj);
    T Replace<T> (T obj) where T : IDbObject;
    Task<T> ReplaceAsync<T> (T obj) where T : IDbObject;
    T Delete<T> (T obj) where T : IDbObject;
    Task<T> DeleteAsync<T> (T obj) where T : IDbObject;

}
