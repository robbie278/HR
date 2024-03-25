using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.UserFeatures.UpdateUser;

public sealed class UpdateMapper : Profile
{
    public UpdateMapper()
    {
        CreateMap<UpdateUserRequest, User>();
        CreateMap<User, UpdateUserResponse>();
    }
}