using Session.NET.Models.CategoryModels;
using Session.NET.Models.UsersModels;
using System.Collections.Generic;

namespace Session.NET.Models.CommonModels
{
    public class CommonResponseModel
    {
        public List<CategoryResponseModel> categoriesText { get; set; }
        public UsersResponseModel usersText { get; set; }
    }
}
