﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}