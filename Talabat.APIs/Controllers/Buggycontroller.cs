using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Errors;
using Talabat.Repository.Data;

namespace Talabat.APIs.Controllers
{
    
    public class Buggycontroller : BaseApiController
    {
        private readonly StoreContext _dbContext;

        public Buggycontroller(StoreContext dbContext)
        {
           _dbContext = dbContext;
        }
        [HttpGet("notfound")] //Get : api/buggy/notfound

        public ActionResult GetNotFoundRequest()
        {
            var product = _dbContext.Products.Find(100);
            if(product is null) return NotFound(new ApiResponse(404));

            return Ok(product);
        }

        [HttpGet("servererror")] //Get : Api/buggy/servererror

        public ActionResult GetServerError()
        {
            var product = _dbContext.Products.Find(100);
            var ProductToReturn = product.ToString(); // will throw Exception [NullRefernceException]

            return Ok(ProductToReturn);
                                                      
        }
        [HttpGet("badrequest")] //Get :Api/buggy/BadRequest

        public ActionResult GetBadRequest()
        {
            return BadRequest( new ApiResponse(400));
        }

        [HttpGet("badrequest /{id}")] //GET : Api/buggy/badrequest/five

        public ActionResult  GetBadReqest(int id) //validation Error
        {
            return Ok();
        }

        [HttpGet("unauthorized")] //GET :Api/buggy/Unauthorized

        public ActionResult GetUnauthorizedError()
        {
            return Unauthorized(new ApiResponse(401));
        }
    }
}
