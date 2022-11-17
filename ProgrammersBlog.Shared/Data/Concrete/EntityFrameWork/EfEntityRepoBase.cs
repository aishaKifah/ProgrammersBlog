using Microsoft.EntityFrameworkCore;
using programamersBlog.Shared.Data.Abstract;
using programamersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


public class EfEntityRepoBase<TEntity> : IEntityRepo<TEntity> where TEntity : class, IEntity, new()
{
    private readonly DbContext _context;
    public EfEntityRepoBase(DbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AnyAysnc(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CountAysnc(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }
    //from c# 2.0 anonymous method inline unnamed method in the code.has the only body without a name, optional parameters and return type.
    public async Task DeleteAsync(TEntity entuty)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<TEntity>> GetAllAysnc(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeproperties)
    {
        throw new NotImplementedException();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeproperties)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}

