using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models;

namespace MyWebApplication.Controllers;

public class HomeController : Controller
{
    [AllowAnonymous]
    public IActionResult Index(string search)
    {
        ViewBag.search=search;
        return View();
    }

    
}
