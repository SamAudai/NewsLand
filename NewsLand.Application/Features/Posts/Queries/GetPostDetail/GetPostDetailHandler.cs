using AutoMapper;
using MediatR;
using NewsLand.Application.Contracts;

namespace NewsLand.Application.Features.Posts.Queries.GetPostDetail
{
    public class GetPostDetailHandler : IRequestHandler<GetPostDetailQuery, GetPostDetailViewModel>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetPostDetailHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        async Task<GetPostDetailViewModel> IRequestHandler<GetPostDetailQuery, GetPostDetailViewModel>.Handle(GetPostDetailQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetPostByIdAsync(request.PostId, true);
            return _mapper.Map<GetPostDetailViewModel>(post);
        }
    }
}
