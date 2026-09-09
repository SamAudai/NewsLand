using AutoMapper;
using MediatR;
using NewsLand.Application.Contracts;
using NewsLand.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsLand.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IAsyncRepository<Post> postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Post>(request);
            await _postRepository.UpdateAsync(post);
        }
    }
}
