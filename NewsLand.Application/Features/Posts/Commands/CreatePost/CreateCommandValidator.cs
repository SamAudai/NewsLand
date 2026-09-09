using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsLand.Application.Features.Posts.Commands.CreatePost
{
    public class CreateCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.")
                .NotNull().WithMessage("Title cannot be null.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .NotNull().WithMessage("Content cannot be null.");
        }
    }
}
