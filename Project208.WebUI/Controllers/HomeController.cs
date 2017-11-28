using Microsoft.AspNetCore.Mvc;

namespace Project208.WebUI.Controllers
{
    [Route("")]
    [Route("TrangChu")]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}