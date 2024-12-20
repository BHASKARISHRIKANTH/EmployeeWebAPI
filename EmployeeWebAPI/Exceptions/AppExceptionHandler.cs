﻿using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Exceptions
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if (exception is ValidationException)
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.ExceptionMessage = exception.Message;
                response.Title = "Validation Error";
            }
            else if (exception is EmployeeNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Employee Not Found";
            }

            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.ExceptionMessage = exception.Message;
                response.Title = "Something went wrong!";
            }

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;

        }
    }
}
