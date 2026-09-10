using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.NativeInterop;
using NewsLand.Application.Features.Posts.Commands.CreatePost;
using NewsLand.Application.Features.Posts.Commands.DeletePost;
using NewsLand.Application.Features.Posts.Commands.UpdatePost;
using NewsLand.Application.Features.Posts.Queries.GetPostDetail;
using NewsLand.Application.Features.Posts.Queries.GetPostsList;

namespace NewsLand.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: PostController
        [HttpGet("All", Name = "GetAllPosts")]
        public async Task<ActionResult<List<GetPostsListViewModel>>> GetAllPosts()
        {
            var dto = await _mediator.Send(new GetPostsListQuery());
            return Ok(dto); 
        }

        // GET: PostController/Details/5
        [HttpGet("{id}", Name = "GetPostById")]
        public async Task<ActionResult<GetPostDetailViewModel>> GetPostById(Guid id)
        {
            var dto = await _mediator.Send(new GetPostDetailQuery { PostId = id });
            return Ok(dto);
        }

        // GET: PostController/Create
        [HttpPost("Create", Name = "CreatePost")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePostCommand createPostCommand )
        {
           Guid id = await _mediator.Send(createPostCommand);
            return Ok(id);
        }


        // GET: PostController/Edit/5
        [HttpPut("Update", Name = "UpdatePost")]
        public async Task<ActionResult> Update([FromBody] UpdatePostCommand updatePostCommand)
        {
            await _mediator.Send(updatePostCommand);
            return NoContent();
        }

        // GET: PostController/Delete/5
        [HttpDelete("{id}", Name = "DeletePost")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePostCommand = new DeletePostCommand { PostId = id };
            await _mediator.Send(deletePostCommand);
            return NoContent();
        }

    }
}
