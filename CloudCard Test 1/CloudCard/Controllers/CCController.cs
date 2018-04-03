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

        //MA where all the real work is done
            //String arguments passed into this method via the URL
            //it is setting email, name etc as whatever comes after the equals sign
        public IActionResult Working(string Email, string Name, string ID, string Campus)
        {
            //created an array called args that is formatted in a way the program can understand
            //sets email id and name to their appropriate values
            string[] args =
            {
            "authToken=qcp435enhuf196ofetlvf7guk1i6ihbd",
            "baseURL=app.cloudcardtools.com",
            "email=" + Email,
            "idNumber=" + ID,
            "name="+ Name
            };

            //currently just a test line to read the arrays contents
            //open output debug and search "HEY" to find it
            System.Diagnostics.Debug.WriteLine("HEY LOOK AT ME");
            foreach (string arg in args)
            {
                System.Diagnostics.Debug.WriteLine(arg);
            }

            //Beginning of what Tonys application was
            Settings Settings = new Settings(args);

            return View();
        }

        public IActionResult GetLink()
        {
            return View();
        }

        public IActionResult Error_Default()
        {
            return View();
        }

        public IActionResult Error_TimeOut()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
