using BaseLayer.Response;
using MediatR;
using SchemaLayer;

namespace OperationLayer;

public record CreateOrderCommand(CustomerOrderRequest Model) : IRequest<ApiResponse<CustomerOrderResponse>>;
public record UpdateOrderCommand(int Id, CustomerOrderUpdatedRequest Model) : IRequest<ApiResponse>;
public record DeleteOrderCommand(int Id) : IRequest<ApiResponse>;
public record GetAllOrderQuery() : IRequest<ApiResponse<List<CustomerOrderResponse>>>;
public record GetOrderByIdQuery(int Id) : IRequest<ApiResponse<CustomerOrderResponse>>;
public record GetOrderByUserIdQuery(int UserId) : IRequest<ApiResponse<List<CustomerOrderResponse>>>;

