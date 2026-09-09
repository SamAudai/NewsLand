using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsLand.Application.Features.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public Guid PostId { get; set; }
    }
}
