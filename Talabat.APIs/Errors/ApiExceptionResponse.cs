namespace Talabat.APIs.Errors
{
    public class ApiExceptionResponse:ApiResponse
    {
        public String? Details { get; set; }
        public ApiExceptionResponse(int statusCode ,string? message = null,string? details = null)
            :base(statusCode,message)
        {
            Details = details;
        }


    }
}
