using Microsoft.EntityFrameworkCore;
using NewsLand.Application.Contracts;
using NewsLand.Domain;

namespace NewsLand.Persistence.Repositiries
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly PostDbContext _postDbContext;

        public PostRepository(PostDbContext postDbContext) : base(postDbContext)
        {
            _postDbContext = postDbContext;
        }

        public async Task<IReadOnlyList<Post>> GetAllPostsAsync(bool includeCategory)
        {
            List<Post> allPosts = new List<Post>();
            allPosts = includeCategory ? await _postDbContext.Posts.Include(x => x.Category).ToListAsync() : await _postDbContext.Posts.ToListAsync();
            return allPosts;
        }

        public async Task<Post> GetPostByIdAsync(Guid id, bool includeCategory)
        {
            Post? post = new Post();
            post = includeCategory ? await _postDbContext.Posts.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id) : await GetByIdAsync(id);
            return post;
        }
    }
}
