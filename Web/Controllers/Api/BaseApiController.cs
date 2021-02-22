using Microsoft.AspNetCore.Mvc;

namespace FamTrees.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}