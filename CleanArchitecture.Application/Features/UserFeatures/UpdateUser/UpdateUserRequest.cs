using MediatR;

namespace CleanArchitecture.Application.Features.UserFeatures.UpdateUser;

public sealed record UpdateUserRequest(Guid id,string Email, string Name) : IRequest<UpdateUserResponse>;