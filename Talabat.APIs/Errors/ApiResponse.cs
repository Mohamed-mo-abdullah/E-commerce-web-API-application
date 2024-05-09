﻿
using System;

namespace Talabat.APIs.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }

        public string? Message { get; set; }

        public ApiResponse( int statusCode ,string? message  = null)
        {
            statusCode = StatusCode;
            Message = message ?? GetDefaultMessageForStatusCodes(statusCode);
        }

        private string? GetDefaultMessageForStatusCodes(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource was not Found",
                500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate.Hate leads to career thange",
                _ => null
            };
        }
    }
}
