using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Session.NET.Models;
using Session.NET.Models.CategoryModels;
using Session.NET.Models.UsersModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Session.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor httpContext;


        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor _httpContext)
        {
            _logger = logger;
            httpContext = _httpContext;
        }

        public IActionResult Index()
        {


            return View();
        }

        public IActionResult Privacy()
        {

            List<CategoryResponseModel> categories = new List<CategoryResponseModel>();
            categories.Add(new CategoryResponseModel { Id = 1, Name = "Kitap", State = true });
            categories.Add(new CategoryResponseModel { Id = 2, Name = "Müzik", State = true });
            categories.Add(new CategoryResponseModel { Id = 3, Name = "Resim", State = false });

            string categoryString = JsonConvert.SerializeObject(categories);
            httpContext.HttpContext.Session.SetString("categorySessionDataList", categoryString);





            UsersResponseModel users = new UsersResponseModel();
            users.Id = 1;
            users.UserName="Test";
            users.Password= "12345";
            string userString = JsonConvert.SerializeObject(users);
            httpContext.HttpContext.Session.SetString("userSessionData", userString);



            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
