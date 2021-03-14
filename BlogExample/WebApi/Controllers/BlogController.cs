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
    public class BlogController : ControllerBase
    {
        private readonly IBaseCrud _baseCrud;
        public BlogController(IBaseCrud baseCrud)
        {
            _baseCrud = baseCrud;
        }

        [HttpPost(nameof(CreateBlog))]
        public IActionResult CreateBlog(Blog blog)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Content", blog.Content, DbType.String);
            dbPara.Add("CategoryId", blog.CategoryId, DbType.Int32);
            dbPara.Add("Picture", blog.Picture, DbType.String);
            dbPara.Add("Title", blog.Title, DbType.String);
            dbPara.Add("Writer", blog.Writer, DbType.String);

            var query = "insert into Blogs(Content,CategoryId, Picture, Title, Writer) values(@Content,@CategoryId, @Picture, @Title, @Writer)";
            var result = _baseCrud.Insert<int>(query, dbPara, commandType: CommandType.Text);
            if (!result)
            {
                ModelState.AddModelError("", "Somethinks went wrong when creating Blog");
                return BadRequest(ModelState);
            }
            return Ok(result);
        }

        [HttpGet(nameof(GetBlogById))]
        public IActionResult GetBlogById(int Id)
        {
            var result = _baseCrud.Get<Blog>($"Select * from [Blogs] where Id = {Id}", null, commandType: CommandType.Text);
            if (result == null)
            {
                ModelState.AddModelError("", "Somethinks went wrong when getting Blog");
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet(nameof(GetBlogList))]
        public IActionResult GetBlogList()
        {
            var result = _baseCrud.GetAll<Blog>($"Select * from [Blogs]", null, commandType: CommandType.Text);
            if (result == null)
            {
                ModelState.AddModelError("", "Somethinks went wrong when listing Blog");
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete(nameof(DeleteBlog))]
        public IActionResult DeleteBlog(int Id)
        {
            var result = _baseCrud.Execute($"Delete [Blogs] Where Id = {Id}", null, commandType: CommandType.Text);
            if (!result)
            {
                ModelState.AddModelError("", "Somethinks went wrong when deleting Blog");
                return BadRequest(ModelState);
            }
            return Ok(result);
        }

        [HttpPost(nameof(UpdateBlog))]
        public IActionResult UpdateBlog(Blog blog)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Id", blog.Id, DbType.Int32);
            dbPara.Add("Content", blog.Content, DbType.String);
            dbPara.Add("CategoryId", blog.CategoryId, DbType.Int32);
            dbPara.Add("Picture", blog.Picture, DbType.String);
            dbPara.Add("Title", blog.Title, DbType.String);
            dbPara.Add("Writer", blog.Writer, DbType.String);

            var query = "update Blogs set Content=@Content, CategoryId=@CategoryId, Picture=@Picture, Title=@Title, Writer=@Writer where Id=@Id";
            var updateArticle = _baseCrud.Update<int>(query, dbPara, commandType: CommandType.Text);
            if (!updateArticle)
            {
                ModelState.AddModelError("", "Somethinks went wrong when updateing Blog");
                return BadRequest(ModelState);
            }
            return Ok(updateArticle);
        }
    }

}
