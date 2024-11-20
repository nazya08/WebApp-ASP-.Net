// Контролер AboutController.cs
using Microsoft.AspNetCore.Mvc;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View("/Views/Home/About.cshtml");
    }
}
