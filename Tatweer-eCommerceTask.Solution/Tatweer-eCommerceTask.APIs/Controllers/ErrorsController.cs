using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tatweer_eCommerceTask.APIs.Errors;

namespace Tatweer_eCommerceTask.APIs.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public ActionResult Error(int code)
        {
            return NotFound(new ApiErrorResponse(code));
        }

    }
}
