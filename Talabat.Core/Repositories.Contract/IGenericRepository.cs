﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Repositories.Contract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetAysnc(int Id);

        Task<IEnumerable<T>> GetAllAysnc();
    }
}
