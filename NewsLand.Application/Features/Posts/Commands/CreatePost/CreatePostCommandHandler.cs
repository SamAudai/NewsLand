using AutoMapper;
using MediatR;
using NewsLand.Application.Contracts;
using NewsLand.Domain;

namespace NewsLand.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Post>(request);
            CreateCommandValidator validator = new CreateCommandValidator();
            var result = await validator.ValidateAsync(request);
            if(!result.Errors.Any())
            {
                await _postRepository.CreateAsync(post);
                return post.Id;
            }
            throw new InvalidOperationException("Invalid post data");
        }
    }
}
