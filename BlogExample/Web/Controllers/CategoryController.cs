using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Repository.Abstract;
using Web.Statics;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<IActionResult> GetAllCategory()
        {
            var data = await _categoryRepo.GetAll(StaticDetails.GetCategoryList);
            return View(data);
        }

        public async Task<IActionResult> CategoryDetail(int Id)
        {
            var data = await _categoryRepo.GetbyId(StaticDetails.GetCategoryById, Id);
            return View(data);
        }

    }
}
