using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Core.Repositories.Contract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAysnc();

        Task<T?> GetAysnc(int Id);

        Task<IEnumerable<T>> GetAllWithSpecAysnc(ISpecification<T> spec);

        Task<T?> GetWithSpecAysnc(ISpecification<T> spec);
    }
}
