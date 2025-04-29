using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{

    private readonly ILogger<PostController> _logger;
    private readonly PostContext db;


    public PostController(ILogger<PostController> logger, PostContext db)
    {
        _logger = logger;
        this.db = db;
    }


    [HttpGet(Name = "Social Posts")]
    public IEnumerable<Post> Get()
    {
        return db.Posts.ToList();
    }


    [HttpPost(Name = "Create Post")]
    public async Task<ActionResult<Post>> Post(PostDTO postData)
    {
        Post newPost = new Post();
        newPost.Title = postData.Title;
        newPost.Description = postData.Description;

        db.Posts.Add(newPost);
        return CreatedAtAction(nameof(Get), new { id = newPost.Id }, newPost);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> PostTodoItem(int id)
    {

        if (id <= 0)
        {
            return BadRequest();
        }


        Post post = await db.Posts.FindAsync(id);

        if (post == null)
        {
            return NotFound("Post not found!");
        }

        return post;
    }



    [HttpPut("{id}")]
    public async Task<ActionResult> PostTodoItem(int id, UpdatePostDTO postData)
    {

        if (id <= 0)
        {
            return BadRequest();
        }


        Post post = await db.Posts.FindAsync(id);

        if (post == null)
        {
            return NotFound("Post not found!");
        }


        post.Title = postData.Title ?? post.Title;
        post.Description = postData.Description ?? post.Description;

        await db.SaveChangesAsync();
        return Ok(new { message = "Updated post!" });
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(int id)
    {

        if (id <= 0)
        {
            return BadRequest();
        }


        Post post = await db.Posts.FindAsync(id);

        if (post == null)
        {
            return NotFound("Post not found!");
        }

        db.Posts.Remove(post);
        await db.SaveChangesAsync();

        return Ok(new { message = "Deleted posts!" });
    }

}

