using BaseLayer.Response;
using MediatR;
using SchemaLayer;

namespace OperationLayer;

public record CreateMailCommand(MailRequest Model) : IRequest<ApiResponse>;
