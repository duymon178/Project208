using Microsoft.AspNetCore.Mvc;

namespace Project208.WebUI.Controllers
{
    [Route("KhachHang")]
    public class CustomerController : Controller
    {
        public IActionResult Index() => View();
    }
}