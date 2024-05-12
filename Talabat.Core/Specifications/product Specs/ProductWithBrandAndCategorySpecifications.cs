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
        public ProductWithBrandAndCategorySpecifications(string sort ,int? brandId,int? categoryId)
            :base(p => 
            
                     (!brandId.HasValue || p.BrandId == brandId.Value) &&
                     (!categoryId.HasValue || p.CategoryId ==categoryId.Value)
            )
        {
            AddIncludes();

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "PriceAsc":
                        //OrderBy = p => p.Price;
                        AddOrderBy(p => p.Price);
                        break;
                    case "PriceDesc":
                        //OrderByDesc = p => p.Price;
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
            else
                AddOrderBy(p => p.Name);
        }
        // This Constructor will be used for creating An object, that will be used to get a specific product with id
        public ProductWithBrandAndCategorySpecifications(int id) 
            : base(p =>p.Id == id)
        {
            AddIncludes();
        }
        private void AddIncludes()
        {

            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }
}
