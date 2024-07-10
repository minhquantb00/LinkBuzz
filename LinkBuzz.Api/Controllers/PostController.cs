using LinkBuzz.Api.Attributes;
using LinkBuzz.Application.InterfaceService;
using LinkBuzz.Domain.Entities.PostEntities;
using LinkBuzz.Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace LinkBuzz.Api.Controllers
{
    [Route(Constants.DefaultValue.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IResponseCacheService _responseCacheService;
        public PostController(IPostService postService, IResponseCacheService responseCacheService)
        {
            _postService = postService;
            _responseCacheService = responseCacheService;
        }
        [HttpGet]
        [Cache(100)]
        public async Task<IActionResult> GetAllPost(string? keyword, int pageIndex = 1, int pageSize = 10)
        {
            return Ok(await _postService.GetAllPost(keyword, pageIndex, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost()
        {
            await _responseCacheService.RemoveCacheResponseAsync("/api/Post/GetAllPost");
            return Ok();
        }
    }
}
