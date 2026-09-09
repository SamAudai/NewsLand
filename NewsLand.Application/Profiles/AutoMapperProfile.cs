using AutoMapper;
using NewsLand.Application.Features.Posts.Commands.CreatePost;
using NewsLand.Application.Features.Posts.Commands.DeletePost;
using NewsLand.Application.Features.Posts.Commands.UpdatePost;
using NewsLand.Application.Features.Posts.Queries.GetPostDetail;
using NewsLand.Application.Features.Posts.Queries.GetPostsList;
using NewsLand.Domain;

namespace NewsLand.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, GetPostsListViewModel>().ReverseMap();
            CreateMap<Post, GetPostDetailViewModel>().ReverseMap();
            CreateMap<Post, CreatePostCommand>().ReverseMap();
            CreateMap<Post, DeletePostCommand>().ReverseMap();
            CreateMap<Post, UpdatePostCommand>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
