using BaseLayer.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OperationLayer;
using SchemaLayer;
using System.Data;

namespace Api.Controllers;

[Route("DealerSystem/[controller]")]
[ApiController]
public class CustomerOrdersController : ControllerBase
{
    private IMediator mediator;

    public CustomerOrdersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ApiResponse<List<CustomerOrderResponse>>> GetAll()
    {
        var operation = new GetAllOrderQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<CustomerOrderResponse>> GetById(int id)
    {
        var operation = new GetOrderByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("UserOrders/{UserId}")]
    public async Task<ApiResponse<List<CustomerOrderResponse>>> GetByUserId(int UserId)
    {
        var operation = new GetOrderByUserIdQuery(UserId);
        var result = await mediator.Send(operation);
        return result;
    }


    [HttpPost]

    public async Task<ApiResponse<CustomerOrderResponse>> Post([FromBody] CustomerOrderRequest request)
    {
        var operation = new CreateOrderCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse> Put(int id, [FromBody] CustomerOrderUpdatedRequest request)
    {
        var operation = new UpdateOrderCommand(id, request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteOrderCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}
