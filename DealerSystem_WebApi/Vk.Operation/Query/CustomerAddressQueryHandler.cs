using AutoMapper;
using BaseLayer.Response;
using DataLayer.Model;
using DataLayer.Uow;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchemaLayer;


namespace OperationLayer.Query;

public class CustomerAddressQueryHandler :
    IRequestHandler<GetAllAddressQuery, ApiResponse<List<CustomerAddressResponse>>>,
    IRequestHandler<GetAddressByIdQuery, ApiResponse<CustomerAddressResponse>>,
    IRequestHandler<GetAddressByUserIdQuery, ApiResponse<List<CustomerAddressResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CustomerAddressQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<CustomerAddressResponse>>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
    {
        List<CustomerAddress> list = unitOfWork.CustomerAddressRepository.GetAll("User");
        List<CustomerAddressResponse> mapped = mapper.Map<List<CustomerAddressResponse>>(list);
        return new ApiResponse<List<CustomerAddressResponse>>(mapped);
    }

    public async Task<ApiResponse<CustomerAddressResponse>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        CustomerAddress entity = await unitOfWork.CustomerAddressRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return new ApiResponse<CustomerAddressResponse>("Record not found");
        }

        CustomerAddressResponse mapped = mapper.Map<CustomerAddressResponse>(entity);
        return new ApiResponse<CustomerAddressResponse>(mapped);
    }

    public async Task<ApiResponse<List<CustomerAddressResponse>>> Handle(GetAddressByUserIdQuery request, CancellationToken cancellationToken)
    {
        List<CustomerAddress> entity =  unitOfWork.CustomerAddressRepository.GetUserAddresses(request.UserId);
        if (entity is null)
        {
            return new ApiResponse<List<CustomerAddressResponse>>("Record not found");
        }

        List<CustomerAddressResponse> mapped = mapper.Map<List<CustomerAddressResponse>>(entity);
        return new ApiResponse<List<CustomerAddressResponse>>(mapped);
    }
}
