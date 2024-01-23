using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Session.NET.Models.UsersModels;
using System.Collections.Generic;

namespace Session.NET.Controllers
{
    public class TestController : Controller
    {
        IHttpContextAccessor httpContextAccessor;

        public TestController(IHttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
        }
        public IActionResult Index()
        {
            UsersResponseModel user = new UsersResponseModel();
            user.Id = 1;
            user.Password = "password";
            user.UserName = "username";

            var userJson = JsonConvert.SerializeObject(user);
            httpContextAccessor.HttpContext.Session.SetString("sessionUser", userJson);


            List<UsersResponseModel> userList = new List<UsersResponseModel>()
            {
                new UsersResponseModel { Id = 1,UserName="Samet"},
                new UsersResponseModel { Id = 2,UserName="Deniz"},
                new UsersResponseModel { Id = 3,UserName="Gözde"},
                new UsersResponseModel { Id = 4,UserName="Ömür"},
                new UsersResponseModel { Id = 5,UserName="İrem"}
            };

            var userListJson = JsonConvert.SerializeObject(userList);
            httpContextAccessor.HttpContext.Session.SetString("sessionUserList",userListJson);


            UsersResponseModel userD = new UsersResponseModel();
            var USER = httpContextAccessor.HttpContext.Session.GetString("sessionUser");
            userD = JsonConvert.DeserializeObject<UsersResponseModel>(USER);


            List<UsersResponseModel> userListD = new List<UsersResponseModel>();
            var USERLIST = httpContextAccessor.HttpContext.Session.GetString("sessionUserList");
            userListD = JsonConvert.DeserializeObject<List<UsersResponseModel>>(USERLIST);



            return View();
        }


    }
}
