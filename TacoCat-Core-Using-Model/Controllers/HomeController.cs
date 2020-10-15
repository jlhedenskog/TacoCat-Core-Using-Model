
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TacoCat_Core_Using_Model.Models;

namespace TacoCat_Core_Using_Model.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TacoCat()
        {
            var tacoCatModel = new TacoCatModel();
            return View(tacoCatModel);
        }
        [HttpPost]
        public IActionResult TacoCat(string userWord)
        {
            var tacoCatModel = new TacoCatModel();
            var userWordNoSpace = userWord.Replace(" ", "").ToLower();
            var reverseWord = string.Join("", userWordNoSpace.Reverse().ToArray());
            if (reverseWord == userWordNoSpace)
            {
                tacoCatModel.ReverseWord = userWord;
            } else
            {
                tacoCatModel.ReverseWord = string.Join("", userWord.Reverse().ToArray());
            }
            tacoCatModel.Result = userWordNoSpace == reverseWord ? "success" : "fail";
            tacoCatModel.UserWord = userWord;
            return View(tacoCatModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
