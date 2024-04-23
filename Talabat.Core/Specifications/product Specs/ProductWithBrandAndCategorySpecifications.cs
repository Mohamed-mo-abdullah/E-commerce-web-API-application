using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications.product_Specs
{
    public class ProductWithBrandAndCategorySpecifications :BaseSpecification<Product>
    {
        // this Constractor is used for Get All Products
        public ProductWithBrandAndCategorySpecifications()
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }
}
