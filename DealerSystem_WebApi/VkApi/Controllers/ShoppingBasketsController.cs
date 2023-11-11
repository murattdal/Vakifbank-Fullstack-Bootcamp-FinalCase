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
public class ShoppingBasketsController : ControllerBase
{
    private IMediator mediator;

    public ShoppingBasketsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ApiResponse<List<ShoppingBasketResponse>>> GetAll()
    {
        var operation = new GetAllBasketQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<ShoppingBasketResponse>> GetById(int id)
    {
        var operation = new GetBasketByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("UserBaskets/{UserId}")]
    public async Task<ApiResponse<List<ShoppingBasketResponse>>> GetByUserId(int UserId)
    {
        var operation = new GetBasketByUserIdQuery(UserId);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("OrderBaskets/{OrderId}")]
    public async Task<ApiResponse<List<ShoppingBasketResponse>>> GetByOrderId(int OrderId)
    {
        var operation = new GetBasketByUserIdQuery(OrderId);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("ProductBaskets/{ProductId}")]
    public async Task<ApiResponse<List<ShoppingBasketResponse>>> GetByProductId(int ProductId)
    {
        var operation = new GetBasketByUserIdQuery(ProductId);
        var result = await mediator.Send(operation);
        return result;
    }


    [HttpPost]
    public async Task<ApiResponse<ShoppingBasketResponse>> Post([FromBody] ShoppingBasketRequest request)
    {
        var operation = new CreateBasketCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse> Put(int id, [FromBody] ShoppingBasketUpdatedRequest request)
    {
        var operation = new UpdateBasketCommand(id, request);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpDelete("{id}")]
    public async Task<ApiResponse> Delete(int id)
    {
        var operation = new DeleteBasketCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}
