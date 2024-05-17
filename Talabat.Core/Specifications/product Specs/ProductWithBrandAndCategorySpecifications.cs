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
        public ProductWithBrandAndCategorySpecifications(ProductSpecParams specParams)
            :base(p => 
                     (string.IsNullOrEmpty(specParams.Search) || p.Name.ToLower().Contains(specParams.Search))&&
                     (! specParams.BrandId.HasValue || p.BrandId == specParams.BrandId.Value) &&
                     (!specParams.CategoryId.HasValue || p.CategoryId == specParams.CategoryId.Value)
            )
        {
            AddIncludes();

            if (!string.IsNullOrEmpty(specParams.sort))
            {
                switch (specParams.sort)
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
                
            //totalproduct = 18 ~ 20
            // pageSize  = 5; 
            //pageIndex =  3;
                ApplyPagination((specParams.PageIndex-1)* specParams.PageSize, specParams.PageSize);       
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
