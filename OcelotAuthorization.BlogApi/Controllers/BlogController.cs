using Microsoft.AspNetCore.Mvc;
using OcelotAuthorization.BlogApi.Models;

namespace OcelotAuthorization.BlogApi.Controllers;

[Route("api")]
[ApiController]
public class BlogController : ControllerBase
{
    [HttpGet("blog")]
    public IActionResult GetBlogs()
    {
        var lst = new List<BlogModel>()
        {
            new BlogModel()
            {
                BlogId = 1,
                BlogTitle = "Blog Title 1",
                BlogAuthor = "Blog Author 1",
                BlogContent = "Blog Content 1"
            },
            new BlogModel()
            {
                BlogId = 2,
                BlogTitle = "Blog Title 2",
                BlogAuthor = "Blog Author 2",
                BlogContent = "Blog Content 2"
            }
        };

        return Ok(lst);
    }
}
