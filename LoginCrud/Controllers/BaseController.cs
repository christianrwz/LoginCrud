using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginCrud.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
