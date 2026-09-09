using MediatR;

namespace NewsLand.Application.Features.Posts.Queries.GetPostsList
{
    public class GetPostsListQuery : IRequest<List<GetPostsListViewModel>>
    {
    }
}
