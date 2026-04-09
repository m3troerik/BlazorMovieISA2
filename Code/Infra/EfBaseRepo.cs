using Abc.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Infra;

public class EfBaseRepo<TContext, TEntity>(TContext c) : IRepo<TEntity>
    where TContext : DbContext
    where TEntity : BaseEntity
{
    protected readonly TContext db = c;

    public async Task<TEntity> CreateAsync(TEntity e)
    {
        await db.AddAsync(e);
        await db.SaveChangesAsync();
        return e;
    }

    public Task DeleteAsync(int id)
    {
        return deleteAsync(id);
    }

    public async Task<TEntity> GetAsync(int id)
    {
        return await db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<TEntity>> GetAsync()
    {
        return await getAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity e)
    {
        db.Update(e);
        await db.SaveChangesAsync();
        return e;
    }
    private async Task deleteAsync(int id)
    {
        var entity = await GetAsync(id);
        if (entity is null) return;
        db.Remove(entity);
        await db.SaveChangesAsync();
    }

    private async Task<IEnumerable<TEntity>> getAsync()
    {
        return await db.Set<TEntity>().ToListAsync();
    }
}

