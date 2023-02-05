using AutoMapper;
using Instagram_Clone_Backend.Dto_s;
using Instagram_Clone_Backend.Models;

namespace Instagram_Clone_Backend.Profiles;

public class PostProfile:Profile
{
    public PostProfile()
    {
        CreateMap<PostDto, Post>();
        CreateMap<CommentDto,Comment>();
    }
}