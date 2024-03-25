using MediatR;

namespace CleanArchitecture.Application.Features.UserFeatures.CreateUser;

public sealed record UpdateUserRequest(string Email, string Name) : IRequest<UpdateUserResponse>;