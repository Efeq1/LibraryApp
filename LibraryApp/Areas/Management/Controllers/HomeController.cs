using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Web.Areas.Management.Controllers;
[Area("Management")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
