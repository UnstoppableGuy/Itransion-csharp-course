using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CollectionPR.Data.Interfaces;
public interface IAbstractRepository<T>  where T : class
{
    void Add(T entity);
    ValueTask<EntityEntry<T>> AddAsync(T entity);
    void Delete(T entity);
    void Commit();
    ValueTask CommitAsync();
    IEnumerable<T> GetAll();
    Task<T?> FindAsync(int id);
    Task<T?> FindAsync(string id);
    T? GetSingle(Expression<Func<T, bool>> predicate);
    ValueTask<T?> GetSingleAsync(Expression<Func<T, bool>> predicate);
    IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
    IQueryable<T> FullTextSearch(string? searchString);
}