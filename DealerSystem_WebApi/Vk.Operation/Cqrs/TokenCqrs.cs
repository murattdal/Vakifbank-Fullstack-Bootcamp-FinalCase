using BaseLayer.Response;
using MediatR;
using SchemaLayer;

namespace OperationLayer;

public record CreateTokenCommand(TokenRequest Model) : IRequest<ApiResponse<TokenResponse>>;
