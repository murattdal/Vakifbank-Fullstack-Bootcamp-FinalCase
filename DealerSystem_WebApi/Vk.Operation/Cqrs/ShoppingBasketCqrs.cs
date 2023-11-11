using BaseLayer.Response;
using MediatR;
using SchemaLayer;

namespace OperationLayer;

public record CreateBasketCommand(ShoppingBasketRequest Model) : IRequest<ApiResponse<ShoppingBasketResponse>>;
public record UpdateBasketCommand(int Id, ShoppingBasketUpdatedRequest Model) : IRequest<ApiResponse>;
public record DeleteBasketCommand(int Id) : IRequest<ApiResponse>;
public record GetAllBasketQuery() : IRequest<ApiResponse<List<ShoppingBasketResponse>>>;
public record GetBasketByIdQuery(int Id) : IRequest<ApiResponse<ShoppingBasketResponse>>;
public record GetBasketByUserIdQuery(int UserId) : IRequest<ApiResponse<List<ShoppingBasketResponse>>>;
public record GetBasketByOrderIdQuery(int UserId) : IRequest<ApiResponse<List<ShoppingBasketResponse>>>;
public record GetBasketByProductIdQuery(int UserId) : IRequest<ApiResponse<List<ShoppingBasketResponse>>>;