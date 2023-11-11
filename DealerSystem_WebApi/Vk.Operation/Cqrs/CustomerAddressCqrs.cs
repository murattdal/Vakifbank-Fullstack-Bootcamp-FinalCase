using BaseLayer.Response;
using MediatR;
using SchemaLayer;

namespace OperationLayer;

public record CreateAddressCommand(CustomerAddressRequest Model) : IRequest<ApiResponse<CustomerAddressResponse>>;
public record UpdateAddressCommand(int Id, CustomerAddressUpdatedRequest Model) : IRequest<ApiResponse>;
public record DeleteAddressCommand(int Id) : IRequest<ApiResponse>;
public record GetAllAddressQuery() : IRequest<ApiResponse<List<CustomerAddressResponse>>>;
public record GetAddressByIdQuery(int Id) : IRequest<ApiResponse<CustomerAddressResponse>>;
public record GetAddressByUserIdQuery(int UserId) : IRequest<ApiResponse<List<CustomerAddressResponse>>>;


