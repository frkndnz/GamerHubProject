using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApplication.ViewComponents
{
    public class GameListComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }   
    }
}