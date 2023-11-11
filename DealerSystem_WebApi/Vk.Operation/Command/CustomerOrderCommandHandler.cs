using AutoMapper;
using BaseLayer.Response;
using DataLayer.Model;
using DataLayer.Uow;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchemaLayer;

namespace OperationLayer.Command;

public class CustomerOrderCommandHandler :
    IRequestHandler<CreateOrderCommand, ApiResponse<CustomerOrderResponse>>,
    IRequestHandler<UpdateOrderCommand, ApiResponse>,
    IRequestHandler<DeleteOrderCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CustomerOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<CustomerOrderResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<CustomerOrder>(request.Model);

        unitOfWork.CustomerOrderRepository.Insert(mapped);
        unitOfWork.CompleteTransaction();
        var response = mapper.Map<CustomerOrderResponse>(mapped);
        return new ApiResponse<CustomerOrderResponse>(response);
    }

    public async Task<ApiResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        CustomerOrder entity = await unitOfWork.CustomerOrderRepository.GetByIdAsync(request.Id, cancellationToken);
        var mapped = mapper.Map<CustomerOrder>(request.Model);

        mapped.Id = request.Id;
        mapped.UserId = request.Model.UserId != default ? request.Model.UserId : entity.UserId;
        mapped.OrderStatus = request.Model.OrderStatus != "string" ? request.Model.OrderStatus : entity.OrderStatus;
        mapped.OrderPaymentMethod = request.Model.OrderPaymentMethod != "string" ? request.Model.OrderPaymentMethod : entity.OrderPaymentMethod;
        mapped.OrderAmount = request.Model.OrderAmount != default ? request.Model.OrderAmount : entity.OrderAmount;

        unitOfWork.CustomerOrderRepository.Update(mapped);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        unitOfWork.CustomerOrderRepository.Delete(request.Id);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }
}
