using System.Linq.Expressions;
using Instagram_Clone_Backend.Data_Access;
using Instagram_Clone_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Clone_Backend.Data_Access;

public class EFentityRepository<TEntity,TContext>:IEFentityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{    

    public TEntity? Get(Expression<Func<TEntity, bool>> filter)
    {
        using var context = new TContext();
        return context.Set<TEntity>().SingleOrDefault(filter);
        
    }

    public List<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null)
    {
        using var context = new TContext();
        var list = context.Set<TEntity>();

        if (filter != null)
        {
            return list.Where(filter).ToList();
        }

        return list.ToList();
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        using var context = new TContext();
        await context.Set<TEntity>().AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public TEntity? Update(TEntity entity)
    {
        using var context = new TContext();
        var dbEntity = context.Set<TEntity>().SingleOrDefault(_entity => _entity.Id == entity.Id);
        if (dbEntity == null) return null!;
        context.Entry(dbEntity).State = EntityState.Detached;
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        using var context = new TContext();
        context.Entry(entity).State = EntityState.Deleted;
        context.SaveChanges();
        return entity;
    }

    public async Task<bool> DoesExitsAsync(int id)
    {
        using var context = new TContext();
        var list  =await context.Set<TEntity>().SingleOrDefaultAsync(t => t.Id == id);
        return list != null;
    }
}