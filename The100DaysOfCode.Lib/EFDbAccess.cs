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

    public T? Get<T>(string fieldname, string fieldvalue) where T : class, IDbObject
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetAsync<T>(string fieldname, string fieldvalue) where T : class, IDbObject
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetManyAsEnumerable<T>() where T : class, IDbObject
    {
        return _context.Set<T>().AsEnumerable<T>();
    }

    public IAsyncEnumerable<T> GetManyAsAsyncEnumerable<T>() where T : class, IDbObject
    {
        return _context.Set<T>().AsAsyncEnumerable();
    }

    public IList<T> GetManyAsList<T>() where T : class, IDbObject
    {
        return _context.Set<T>().ToList();
    }
    public async Task<IList<T>> GetManyAsListAsync<T>() where T : class, IDbObject
    {
        return await _context.Set<T>().ToListAsync();
    }
    public T? GetWithId<T>(int id) where T : class, IDbObject
    {
        return _context.Set<T>().Find(id);
    }

    public async Task<T?> GetWithIdAsync<T>(int id) where T : class, IDbObject
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public bool Replace<T>(T obj) where T : class, IDbObject
    {
        _context.Set<T>().Update(obj);
        int amount = _context.SaveChanges();
        if (amount < 1) return false;
        return true;
    }

    public async Task<bool> ReplaceAsync<T>(T obj) where T : class, IDbObject
    {
        _context.Set<T>().Update(obj);
        int amount = await _context.SaveChangesAsync();
        if (amount < 1) return false;
        return true;
    }

    // public IEnumerable<T> GetList<T>(string fieldname, string fieldvalue) where T : class, IDbObject
    // {
    //     throw new NotImplementedException();
    // }

    // public async Task<IEnumerable<T>> GetListAsync<T>(string fieldname, string fieldvalue) where T : class, IDbObject
    // {
    //     throw new NotImplementedException();
    // }

    public IQueryable GetQueryable<T>() where T : class, IDbObject
    {
        return _context.Set<T>().AsQueryable<T>();
    }
    private async Task ResetId()
    {
        if (_config.GetValue<string>(AppSettings.DatabaseKey) == AppSettings.DatabaseValueSQLite)
        {
            await _context.Database.ExecuteSqlRawAsync("delete from DayOfCode;");
            await _context.Database.ExecuteSqlRawAsync("delete from sqlite_sequence where name='DayOfCode';");
        }
        else if (_config.GetValue<string>(AppSettings.DatabaseKey) == AppSettings.DatabaseValueMssql)
        {
            await _context.Database.ExecuteSqlRawAsync("delete from DayOfCode;");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('DayOfCode', RESEED, 0)");
        }
        _context.SaveChanges();
    }
}
