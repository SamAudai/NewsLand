using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsLand.Application.Features.Posts.Queries.GetPostDetail
{
    public class GetPostDetailQuery : IRequest<GetPostDetailViewModel>
    {
        public Guid PostId { get; set; }
    }
}
