using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Statics
{
    public static class StaticDetails
    {
        public static string BaseUrl = "https://localhost:44308/";
        public static string CreateBlog = BaseUrl+ "api/blog/createblog";
        public static string GetBlogList = BaseUrl+ "api/blog/getbloglist";
        public static string BlogGetById = BaseUrl+ "api/blog/getblogbyid?Id=";
        public static string DeleteBlog = BaseUrl+ "api/blog/deleteblog?Id=";
        public static string UpdateBlog = BaseUrl+ "api/blog/updateblog";
        public static string CreateCategory = BaseUrl+ "api/category/createcategory";
        public static string GetCategoryById = BaseUrl+ "api/category/getcategorybyid?Id=";
        public static string GetCategoryList = BaseUrl+ "api/category/getcategorylist";
        public static string DeleteCategory = BaseUrl+ "api/category/deletecategory?Id=";
        public static string UpdateCategory = BaseUrl+ "api/category/updatecategory";
    }
}
