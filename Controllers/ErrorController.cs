using MasterJob.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace MasterJob.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    //[Route("api/[controller]")]
    //[ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandleError(Exception exception)
        {
            Console.WriteLine("error value >>>>>>>> {0}", exception);
            if (exception is DatabaseRelationalException relationalEx)
            {
                return Problem(
                    detail: relationalEx.Message,
                    title: "A relational database error has occurred.",
                    statusCode: StatusCodes.Status400BadRequest
                );
            }
            else
            {
                return Problem(
                    detail: exception.Message,
                    title: "An unexpected error telah terjadi.",
                    statusCode: StatusCodes.Status500InternalServerError
                );
            }
        }
    }
}
