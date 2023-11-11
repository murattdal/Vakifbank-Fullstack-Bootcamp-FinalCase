using AutoMapper;
using BaseLayer.Response;
using DataLayer.Model;
using DataLayer.Uow;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchemaLayer;

namespace OperationLayer.Query;

public class CustomerOrderQueryHandler :
    IRequestHandler<GetAllOrderQuery, ApiResponse<List<CustomerOrderResponse>>>,
    IRequestHandler<GetOrderByIdQuery, ApiResponse<CustomerOrderResponse>>,
    IRequestHandler<GetOrderByUserIdQuery, ApiResponse<List<CustomerOrderResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CustomerOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<ApiResponse<List<CustomerOrderResponse>>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        List<CustomerOrder> list = unitOfWork.CustomerOrderRepository.GetAll("User");
        List<CustomerOrderResponse> mapped = mapper.Map<List<CustomerOrderResponse>>(list);
        return new ApiResponse<List<CustomerOrderResponse>>(mapped);
    }

    public async Task<ApiResponse<CustomerOrderResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        CustomerOrder entity = await unitOfWork.CustomerOrderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return new ApiResponse<CustomerOrderResponse>("Record not found");
        }

        CustomerOrderResponse mapped = mapper.Map<CustomerOrderResponse>(entity);
        return new ApiResponse<CustomerOrderResponse>(mapped);
    }

    public async Task<ApiResponse<List<CustomerOrderResponse>>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
    {
        List<CustomerOrder> entity = unitOfWork.CustomerOrderRepository.GetUserOrders(request.UserId);
        if (entity is null)
        {
            return new ApiResponse<List<CustomerOrderResponse>>("Record not found");
        }

        List<CustomerOrderResponse> mapped = mapper.Map<List<CustomerOrderResponse>>(entity);
        return new ApiResponse<List<CustomerOrderResponse>>(mapped);
    }
}
