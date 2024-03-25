using CleanArchitecture.Application.Features.UserFeatures.CreateUser;
using CleanArchitecture.Application.Features.UserFeatures.DeleteUser;
using CleanArchitecture.Application.Features.UserFeatures.GetAllUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUserRequest(), cancellationToken);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<UpdateUserResponse>> Create(UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpDelete]
    public async Task<ActionResult<Guid>> Delete(DeleteUserRequest request,
        CancellationToken cancellationToken)
    {
        
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }
}