using AutoMapper;
using Instagram_Clone_Backend.Dto_s;
using Instagram_Clone_Backend.Models;

namespace Instagram_Clone_Backend.Profiles;

public class UserMapProfile:Profile
{
    public UserMapProfile()
    {
        CreateMap<UserDto, User>();
        CreateMap<UserDto, UserProfile>();
    }
}