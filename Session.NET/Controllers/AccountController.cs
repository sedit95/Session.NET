using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Session.NET.Models.CategoryModels;
using Session.NET.Models.CommonModels;
using Session.NET.Models.UsersModels;
using System.Collections.Generic;

namespace Session.NET.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public AccountController(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor=_httpContextAccessor;
        }

        public IActionResult SessionDemo()
        {
            List<CategoryResponseModel> categories = new List<CategoryResponseModel>();
            string categoryString = httpContextAccessor.HttpContext.Session.GetString("categorySessionDataList");
            categories = JsonConvert.DeserializeObject<List<CategoryResponseModel>>(categoryString);
            //ViewBag.Categories = categories;


            UsersResponseModel users = new UsersResponseModel();
            string usersString = httpContextAccessor.HttpContext.Session.GetString("userSessionData");
            users = JsonConvert.DeserializeObject<UsersResponseModel>(usersString);
            //ViewBag.Users = users;

            CommonResponseModel common = new CommonResponseModel();
            common.categoriesText = categories;
            common.usersText = users;

            return View(common);
        }
    }
}
