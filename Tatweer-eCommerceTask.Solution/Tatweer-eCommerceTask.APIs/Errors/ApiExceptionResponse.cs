﻿namespace Tatweer_eCommerceTask.APIs.Errors
{
    public class ApiExceptionResponse : ApiErrorResponse
    {
        public string? Details { get; set; }

        public ApiExceptionResponse(int statuscode, string? message = null, string? details = null) : base(statuscode, message)
        {
            Details = details;
        }
    }
}
