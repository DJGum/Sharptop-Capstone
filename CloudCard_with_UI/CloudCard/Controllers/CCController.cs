using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CloudCard.Models;

namespace CloudCard.Controllers
{
    public class CCController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult GetLink()
        {
            return View();
        }

        public IActionResult Working()
        {
            return View();
        }

        public IActionResult Error_Default()
        {
            return View();
        }

        public IActionResult Error_TimeOut() => View();

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
