using Microsoft.EntityFrameworkCore;

namespace The100DaysOfCode.Lib;

public class EFDbAccess : IDbAccess
{
    private readonly DayOfCodeContext _context;
    public EFDbAccess(DayOfCodeContext context)
    {
        _context = context;
    }
    public void Create<T>(T obj) where T : class, IDbObject
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync<T>(T obj) where T : class, IDbObject
    {
        await _context.Set<T>().AddAsync(obj);
        await _context.SaveChangesAsync();
    }

    public void Delete<T>(T obj) where T : class, IDbObject
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync<T>(T obj) where T : class, IDbObject
    {
        throw new NotImplementedException();
    }

    public T Get<T>(string fieldname, string fieldvalue) where T : class, IDbObject
    {
        throw new NotImplementedException();
    }

    public T GetAsync<T>(string fieldname, string fieldvalue) where T : class, IDbObject
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetList<T>() where T : class, IDbObject
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetListAsync<T>() where T : class, IDbObject
    {
        return await _context.Set<T>().ToListAsync();
    }

    public T GetWithId<T>(int id) where T : class, IDbObject
    {
        throw new NotImplementedException();
    }

    public Task<T> GetWithIdAsync<T>(int id) where T : class, IDbObject
    {
        throw new NotImplementedException();
    }

    public bool Replace<T>(T obj) where T : class, IDbObject
    {
        throw new NotImplementedException();
    }

    public Task<bool> ReplaceAsync<T>(T obj) where T : class, IDbObject
    {
        throw new NotImplementedException();
    }
}
