﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
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
        public async Task<IEnumerable<T>> GetAllAysnc()
        {
             return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAysnc(int Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id);
        }
    }
}