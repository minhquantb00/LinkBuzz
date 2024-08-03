using LinkBuzz.Domain.Domain;
using LinkBuzz.Domain.Events;
using LinkBuzz.Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class EventStoreRepository<T> : IEventStoreRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private DbSet<T> _dbSet;

    protected DbSet<T> DbSet
    {
        get
        {
            if (_dbSet == null)
            {
                _dbSet = _context.Set<T>();
            }
            return _dbSet;
        }
    }

    public EventStoreRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> FindByAggregateId(long objectId)
    {
        return await DbSet
            .Where(x => EF.Property<long>(x, "ObjectId") == objectId)
            .OrderBy(x => EF.Property<int>(x, "Version"))
            .ToListAsync()
            .ConfigureAwait(false);
    }

    public async Task SaveAsync(T entity)
    {
        var entry = _context.Entry(entity);
        if (entry.State == EntityState.Detached)
        {
            DbSet.Add(entity);
        }
        else
        {
            entry.State = EntityState.Modified;
        }
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }
}
