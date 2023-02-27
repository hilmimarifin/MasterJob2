using MasterJob.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace MasterJob.Helper
{
    public class ErrorHandling
    {
    }
    public class DatabaseRelationalException : Exception
    {
        public DatabaseRelationalException(string message) : base(message)
        {
        }
    }

    public class DatabaseRelationalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public DatabaseRelationalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, MasterJobContext dbContext)
        {
            try
            {
                await _next(context);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is PostgresException pgEx && pgEx.SqlState == "23503")
                {
                    // A foreign key constraint violation has occurred.
                    throw new DatabaseRelationalException("A foreign key constraint violation has occurred.");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
