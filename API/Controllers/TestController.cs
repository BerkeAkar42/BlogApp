using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace API.Controllers
{
    [Route("/blogapp.backend/api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public TestController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            try
            {
                var blogs = await _blogService.GetAll();
                return Ok(blogs);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                //throw new Exception("Veriler Getirilirken Bir Hata Oluştu!");
            }
        }


        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetOneBlog([FromRoute] Guid id)
        {
            try
            {
                var blog = await _blogService.GetOne(id);
                return Ok(blog);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateOneBlog(Blog blog)
        {
            try
            {
                await _blogService.Add(blog);
                return StatusCode(201, blog);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteOneBlog([FromRoute] Guid id)
        {
            try
            {
                await _blogService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
