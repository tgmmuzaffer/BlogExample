using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Models;
using Web.Repository.Abstract;
using Web.Statics;

namespace Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepo _blogRepo;
        public BlogController(IBlogRepo blogRepo)
        {
            _blogRepo = blogRepo;
        }
        public async Task<IActionResult> GetAllBlog()
        {
            var data = await _blogRepo.GetAll(StaticDetails.GetBlogList);
           
            return View(data);
        }

     

        public async Task<IActionResult> BlogDetail(int Id)
        {
            var data = await _blogRepo.GetbyId(StaticDetails.BlogGetById, Id);
            return View(data);
        }

    }
}
