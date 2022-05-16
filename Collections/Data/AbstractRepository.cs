using System.Linq.Expressions;
using CollectionPR.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Korzh.EasyQuery.Linq;

namespace CollectionPR.Data.Repositories;

public class AbstractRepository<T> : IAbstractRepository<T> where T : class
{
    private readonly CollectionDbContext context;

    protected AbstractRepository(CollectionDbContext context)
    {
        this.context = context;
    }

    public virtual void Add(T entity)
    {
        this.context.Set<T>().Add(entity);
    }
    
    public virtual async ValueTask<EntityEntry<T>> AddAsync(T entity)
    {
        return await this.context.Set<T>().AddAsync(entity);
    }
    
    public virtual void Delete(T entity)
    {
        EntityEntry dbEntityEntry = this.context.Entry(entity);
        dbEntityEntry.State = EntityState.Deleted;
    }

    public virtual void Commit()
    {
        this.context.SaveChanges();
    }

    public virtual async ValueTask CommitAsync()
    {
        await this.context.SaveChangesAsync();
    }

    public virtual IEnumerable<T> GetAll()
    {
        return this.context.Set<T>().AsEnumerable();
    }

    public T? GetSingle(Expression<Func<T, bool>> predicate)
    {
        return this.context.Set<T>().FirstOrDefault(predicate);
    }
    
    public async ValueTask<T?> GetSingleAsync(Expression<Func<T, bool>> predicate)
    {
        return await this.context.Set<T>().FirstOrDefaultAsync(predicate);
    }
  
    public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
    {
        return this.context.Set<T>().Where(predicate);
    }
    
    public async Task<T?> FindAsync(int id) 
    {
        return await this.context.Set<T>().FindAsync(id);
    }
    public async Task<T?> FindAsync(string id) 
    {
        return await this.context.Set<T>().FindAsync(id);
    }

    public virtual IQueryable<T> FullTextSearch(string? searchString)
    {
        return this.context.Set<T>().FullTextSearchQuery(searchString);
    }
}