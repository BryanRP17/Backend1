using Backend1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend1.DTOs;

namespace Backend1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostsService _titlesService;

        public PostsController (IPostsService titlesService)
        {
            _titlesService = titlesService;
        }

        [HttpGet]

        public async Task<IEnumerable<PostDto>> Get() =>
            await _titlesService.Get();

    }
}
