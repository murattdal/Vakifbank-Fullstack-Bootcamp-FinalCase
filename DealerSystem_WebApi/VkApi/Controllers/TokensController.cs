using Api.Middleware;
using BaseLayer.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationLayer;
using SchemaLayer;

namespace Api.Controllers;

[Route("DealerSystem/[controller]")]
[ApiController]
public class TokensController:ControllerBase
{
    private IMediator mediator;

    public TokensController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpPost]
    public async Task<ApiResponse<TokenResponse>> Post([FromBody] TokenRequest request)
    {
        var operation = new CreateTokenCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }


    [TypeFilter(typeof(LogResourceFilter))]
    [TypeFilter(typeof(LogActionFilter))]
    [TypeFilter(typeof(LogAuthorizationFilter))]
    [TypeFilter(typeof(LogResourceFilter))]
    [TypeFilter(typeof(LogExceptionFilter))]
    [HttpGet("Test")]
    public ApiResponse Get()
    {
        return new ApiResponse();
    }
}
