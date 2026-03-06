using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public TestController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlog()
        {
            try
            {
                await _blogService.GetAll();
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        public async Task<IActionResult> GetOneBlog([FromBody] Blog blog)
        {
            try
            {
                await _blogService.Add(blog);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
