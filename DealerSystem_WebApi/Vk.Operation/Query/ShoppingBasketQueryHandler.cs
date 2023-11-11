using AutoMapper;
using BaseLayer.Response;
using DataLayer.Model;
using DataLayer.Uow;
using MediatR;
using SchemaLayer;

namespace OperationLayer.Query;

public class ShoppingBasketQueryHandler :
    IRequestHandler<GetAllBasketQuery, ApiResponse<List<ShoppingBasketResponse>>>,
    IRequestHandler<GetBasketByIdQuery, ApiResponse<ShoppingBasketResponse>>,
    IRequestHandler<GetBasketByUserIdQuery, ApiResponse<List<ShoppingBasketResponse>>>,
    IRequestHandler<GetBasketByOrderIdQuery, ApiResponse<List<ShoppingBasketResponse>>>,
    IRequestHandler<GetBasketByProductIdQuery, ApiResponse<List<ShoppingBasketResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ShoppingBasketQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<ShoppingBasketResponse>>> Handle(GetAllBasketQuery request, CancellationToken cancellationToken)
    {
        List<ShoppingBasket> list = unitOfWork.ShoppingBasketRepository.GetAll("User");
        List<ShoppingBasketResponse> mapped = mapper.Map<List<ShoppingBasketResponse>>(list);
        return new ApiResponse<List<ShoppingBasketResponse>>(mapped);
    }

    public async Task<ApiResponse<ShoppingBasketResponse>> Handle(GetBasketByIdQuery request, CancellationToken cancellationToken)
    {
        ShoppingBasket entity = await unitOfWork.ShoppingBasketRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return new ApiResponse<ShoppingBasketResponse>("Record not found");
        }

        ShoppingBasketResponse mapped = mapper.Map<ShoppingBasketResponse>(entity);
        return new ApiResponse<ShoppingBasketResponse>(mapped);
    }

    public async Task<ApiResponse<List<ShoppingBasketResponse>>> Handle(GetBasketByUserIdQuery request, CancellationToken cancellationToken)
    {
        List<ShoppingBasket> entity = unitOfWork.ShoppingBasketRepository.GetUserBaskets(request.UserId);
        if (entity is null)
        {
            return new ApiResponse<List<ShoppingBasketResponse>>("Record not found");
        }

        List<ShoppingBasketResponse> mapped = mapper.Map<List<ShoppingBasketResponse>>(entity);
        return new ApiResponse<List<ShoppingBasketResponse>>(mapped);
    }

    public async Task<ApiResponse<List<ShoppingBasketResponse>>> Handle(GetBasketByOrderIdQuery request, CancellationToken cancellationToken)
    {
        List<ShoppingBasket> entity = unitOfWork.ShoppingBasketRepository.GetUserBaskets(request.UserId);
        if (entity is null)
        {
            return new ApiResponse<List<ShoppingBasketResponse>>("Record not found");
        }

        List<ShoppingBasketResponse> mapped = mapper.Map<List<ShoppingBasketResponse>>(entity);
        return new ApiResponse<List<ShoppingBasketResponse>>(mapped);
    }

    public async Task<ApiResponse<List<ShoppingBasketResponse>>> Handle(GetBasketByProductIdQuery request, CancellationToken cancellationToken)
    {
        List<ShoppingBasket> entity = unitOfWork.ShoppingBasketRepository.GetUserBaskets(request.UserId);
        if (entity is null)
        {
            return new ApiResponse<List<ShoppingBasketResponse>>("Record not found");
        }

        List<ShoppingBasketResponse> mapped = mapper.Map<List<ShoppingBasketResponse>>(entity);
        return new ApiResponse<List<ShoppingBasketResponse>>(mapped);
    }
}
