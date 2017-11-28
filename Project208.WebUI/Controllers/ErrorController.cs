using Microsoft.AspNetCore.Mvc;

namespace Project208.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        [Route("[controller]/500")]
        public IActionResult Error500(int code) => BadRequest("Có lỗi hệ thống xảy ra..");

        [Route("[controller]/{code:int}")]
        public IActionResult Index(int code) => View();
    }
}