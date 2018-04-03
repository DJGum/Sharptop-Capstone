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

        //MA
        //String arguments passed into this method via the URL
        public IActionResult GetLink(string Email, string Name, string ID, string Campus)
        {
            //created an array called args that is formatted in a way the program can understand
            //sets email, id, and name to their appropriate values
            string[] studentArgs =
            {
                "authToken=pd9e0qvbs91gtnrna5sevb3l2j7des2c",
                "baseURL=app.cloudcardtools.com",
                "email=" + Email,
                "idNumber=" + ID,
                "name="+ Name
            };

            //Beginning of what Tonys application was
            Settings Settings = new Settings(studentArgs);

            //if missing userinfo redirect to login page
            if (Settings.IsValid)
            {
                return RedirectToAction("Login");
            }

            CloudCardService Service = new CloudCardService(Settings.BaseURL, Settings.AuthToken);

            //Cannot connect to cloudcard
            if (!Service.IsCloudCardUp)
            {
                return RedirectToAction("CloudCardDown");
            }

            //Create or update a person
            String json =
                $@"{{
                    ""email"":""{Settings.Email}"",
                    ""identifier"":""{Settings.IdNumber}""
                }}";

            //Create or update a user
            //try
            //{
            Person Person = Service.CreateOrUpdatePerson(json);
            
            //get login link
            string Link = Service.CreateLoginLink(Settings.IdNumber);

            //Look up a person by their email address
            string Status = (Person.Photo == null) ? "null" : Person.Photo.Status;            

            //*****Redirect to cloudcard automatically*****// 
            //return Redirect(link);

            //redirects to page that displays link and status
            ViewData["Status"] = Status;
            ViewData["Name"] = Name;
            ViewData["Link"] = Link;
            return View();
            //}
            //catch (Exception Noat)
            //{
            //    System.Diagnostics.Debug.WriteLine(Noat.Message);
            //    return Redirect("Login");
            //}
        }

        public IActionResult CloudCardDown()
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