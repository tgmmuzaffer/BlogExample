using Businness.Abstract;
using Dapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBaseCrud _baseCrud;
        public CategoryController(IBaseCrud baseCrud)
        {
            _baseCrud = baseCrud;
        }

        [HttpPost(nameof(CreateCategory))]
        public IActionResult CreateCategory(Category category)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("BlogId", category.BlogId, DbType.Int32);
            dbPara.Add("Name", category.Name, DbType.String);
            
            var query = "insert into Categories(BlogId,Name) values(@BlogId,@Name)";
            var result = _baseCrud.Insert<int>(query, dbPara, commandType: CommandType.Text);
            if (!result)
            {
                ModelState.AddModelError("", "Somethinks went wrong when creating Category");
                return BadRequest(ModelState);
            }
            return Ok(result);
        }

        [HttpGet(nameof(GetCategoryById))]
        public IActionResult GetCategoryById(int Id)
        {
            var result = _baseCrud.Get<Category>($"Select * from [Categories] where Id = {Id}", null, commandType: CommandType.Text);
            if (result == null)
            {
                ModelState.AddModelError("", "Somethinks went wrong when getting Category");
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet(nameof(GetCategoryList))]
        public IActionResult GetCategoryList()
        {
            var result = _baseCrud.GetAll<Category>($"Select * from [Categories]", null, commandType: CommandType.Text);
            if (result==null)
            {
                ModelState.AddModelError("", "Somethinks went wrong when listing Category");
                return NotFound();
            }
            return Ok(result);
            
        }

        [HttpDelete(nameof(DeleteCategory))]
        public IActionResult DeleteCategory(int Id)
        {
            var result = _baseCrud.Execute($"Delete [Categories] Where Id = {Id}", null, commandType: CommandType.Text);
            if (!result)
            {
                ModelState.AddModelError("", "Somethinks went wrong when deleting Category");
                return BadRequest(ModelState);
            }
            return Ok(result);
        }

        [HttpPost(nameof(UpdateCategory))]
        public IActionResult UpdateCategory(Category category)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Id", category.Id, DbType.Int32);
            dbPara.Add("BlogId", category.BlogId, DbType.Int32);
            dbPara.Add("Name", category.Name, DbType.String);

            var query = "update Categories set BlogId=@BlogId, Name=@Name where Id=@Id";
            var updateArticle = _baseCrud.Update<int>(query, dbPara, commandType: CommandType.Text);
            if (!updateArticle)
            {
                ModelState.AddModelError("", "Somethinks went wrong when updateing Category");
                return BadRequest(ModelState);
            }
            return Ok(updateArticle);
        }
    }
}
