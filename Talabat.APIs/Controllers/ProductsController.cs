using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Dtos;
using Talabat.APIs.Errors;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications;
using Talabat.Core.Specifications.product_Specs;

namespace Talabat.APIs.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductCategory> _categoriesRepo;
        private readonly IMapper _mapper;

        public ProductsController(
            IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> brandRepo,
            IGenericRepository<ProductCategory> categoriesRepo,
            IMapper mapper)
        {
            _productsRepo = productsRepo;
            _brandRepo = brandRepo;
            _categoriesRepo = categoriesRepo;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(string? sort ,int? brandId,int? categoryId)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(sort,brandId,categoryId);

            var Products = await _productsRepo.GetAllWithSpecAysnc(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(Products));
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<ProductToReturnDto>> GetProducts(int id)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(id);
            

            var product  = await _productsRepo.GetWithSpecAysnc(spec);

            if(product is null)
                return NotFound(new ApiResponse(404)); //404

            return Ok(_mapper.Map<Product,ProductToReturnDto>(product)); //200
        }

        [HttpGet("brands")] //GET /api/products/brands

        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands = await _brandRepo.GetAllAysnc();
            return Ok(brands);
        }


        [HttpGet("categories")] //GET /api/products/categories

        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetCategories()
        {
            var categories = await _categoriesRepo.GetAllAysnc();
            return Ok(categories);
        }
    }
}
