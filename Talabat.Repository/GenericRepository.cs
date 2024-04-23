using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications;
using Talabat.Infrastrcuture;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbContext;

        public GenericRepository(StoreContext dbContext ) //Ask clr for Creating object from DbContext
        {
            _dbContext = dbContext;
        }
        public async Task<T?> GetAysnc(int Id)
        {
            //if (typeof(T) == typeof(Product))
            //    return  await _dbContext.Set<Product>().Where(p => p.Id == Id).Include(p => p.Brand).Include(p => p.Category).FirstOrDefaultAsync() as T;
                return await _dbContext.Set<T>().FindAsync(Id);
        }
        public async Task<IEnumerable<T>> GetAllAysnc()
        {
            //if(typeof(T) ==typeof(Product)) 
            //    return  (IEnumerable<T>) await _dbContext.Set<Product>().Include(p => p.Brand).Include(p => p.Category).ToListAsync();
             return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithSpecAysnc(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T?> GetWithSpecAysnc(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationsEvaluator<T>.GetQuery(_dbContext.Set<T>(), spec);
        }
    }
}
