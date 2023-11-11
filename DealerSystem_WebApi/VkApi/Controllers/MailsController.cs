using BaseLayer.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationLayer;
using SchemaLayer;

namespace Api.Controllers;

[Route("DealerSystem/[controller]")]
[ApiController]
public class MailsController:ControllerBase
{
    private IMediator mediator;

    public MailsController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpPost]
    public async Task<ApiResponse> Post([FromBody] MailRequest request)
    {
        var operation = new CreateMailCommand(request);
        var result = await mediator.Send(operation);
        return new ApiResponse();
    }

}
