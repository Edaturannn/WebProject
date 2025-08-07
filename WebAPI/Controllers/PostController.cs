using Microsoft.AspNetCore.Mvc;
using WebAPI.Business.Abstract;
using WebAPI.Entity.Concrete;

namespace WebAPI.Controllers;

[Route("posts")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;
    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    [HttpGet("getalllistpostasync")]
    public async Task<IActionResult> GetAllListPostAsync()
    {
        var values = await _postService.GetAllListAsync();
        return Ok(values);
    }
    [HttpPost("createpostasync")]
    public async Task<IActionResult> CreatePostAsync(Post post)
    {
        await _postService.CreateAsync(post);

        return Ok("Başarılı bir şekilde eklendi");
    }
}