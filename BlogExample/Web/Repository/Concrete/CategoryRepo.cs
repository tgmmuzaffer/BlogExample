using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Models;
using Web.Repository.Abstract;

namespace Web.Repository.Concrete
{
    public class CategoryRepo : BaseRepo<Category> , ICategoryRepo
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CategoryRepo(IHttpClientFactory httpClientFactory):base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    }
}
