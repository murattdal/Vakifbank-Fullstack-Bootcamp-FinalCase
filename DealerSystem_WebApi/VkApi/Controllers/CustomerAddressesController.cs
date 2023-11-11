using BaseLayer.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OperationLayer;
using SchemaLayer;

namespace Api.Controllers;

[Route("DealerSystem/[controller]")]
[ApiController]
public class CustomerAddressesController : ControllerBase
{
    private IMediator mediator;

    public CustomerAddressesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ApiResponse<List<CustomerAddressResponse>>> GetAll()
    {
        var operation = new GetAllAddressQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<CustomerAddressResponse>> GetById(int id)
    {
        var operation = new GetAddressByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("UserAddress/{UserId}")]
    public async Task<ApiResponse<List<CustomerAddressResponse>>> GetByUserId(int UserId)
    {
        var operation = new GetAddressByUserIdQuery(UserId);
        var result = await mediator.Send(operation);
        return result;
    }


    [HttpPost]
    public async Task<ApiResponse<CustomerAddressResponse>> Post([FromBody] CustomerAddressRequest request)
    {
        var operation = new CreateAddressCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse> Put(int id, [FromBody] CustomerAddressUpdatedRequest request)
    {
        var operation = new UpdateAddressCommand(id, request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteAddressCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}
