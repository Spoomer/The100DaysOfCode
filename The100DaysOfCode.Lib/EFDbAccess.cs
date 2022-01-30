using Microsoft.EntityFrameworkCore;

namespace The100DaysOfCode.Lib;

public class EFDbAccess : IDbAccess
{
    private readonly DayOfCodeContext _context;
    public EFDbAccess(DayOfCodeContext context)
    {
        _context = context;
    }
    public T Create<T>(T obj) where T : IDbObject
    {
        throw new NotImplementedException();
    }

    public Task<T> CreateAsync<T>(T obj) where T : IDbObject
    {
        throw new NotImplementedException();
    }

    public T Delete<T>(T obj) where T : IDbObject
    {
        throw new NotImplementedException();
    }

    public Task<T> DeleteAsync<T>(T obj) where T : IDbObject
    {
        throw new NotImplementedException();
    }

    public T Get<T>(string fieldname, string fieldvalue) where T : IDbObject
    {
        throw new NotImplementedException();
    }

    public T GetAsync<T>(string fieldname, string fieldvalue) where T : IDbObject
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetList<T>() where T : IDbObject
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetListAsync<T>() where T : class, IDbObject
    {
        return await _context.Set<T>().ToListAsync();
    }

    public T GetWithId<T>(int id) where T : IDbObject
    {
        throw new NotImplementedException();
    }

    public Task<T> GetWithIdAsync<T>(int id) where T : IDbObject
    {
        throw new NotImplementedException();
    }

    public T Replace<T>(T obj) where T : IDbObject
    {
        throw new NotImplementedException();
    }

    public Task<T> ReplaceAsync<T>(T obj) where T : IDbObject
    {
        throw new NotImplementedException();
    }
}
