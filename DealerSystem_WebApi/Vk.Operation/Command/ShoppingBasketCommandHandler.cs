using AutoMapper;
using BaseLayer.Response;
using DataLayer.Model;
using DataLayer.Uow;
using MediatR;
using SchemaLayer;



namespace OperationLayer.Command;

public class ShoppingBasketCommandHandler :
    IRequestHandler<CreateBasketCommand, ApiResponse<ShoppingBasketResponse>>,
    IRequestHandler<UpdateBasketCommand, ApiResponse>,
    IRequestHandler<DeleteBasketCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ShoppingBasketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<ShoppingBasketResponse>> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<ShoppingBasket>(request.Model);

        unitOfWork.ShoppingBasketRepository.Insert(mapped);
        unitOfWork.CompleteTransaction();
        var response = mapper.Map<ShoppingBasketResponse>(mapped);
        return new ApiResponse<ShoppingBasketResponse>(response);
    }

    public async Task<ApiResponse> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
    {
        ShoppingBasket entity = await unitOfWork.ShoppingBasketRepository.GetByIdAsync(request.Id, cancellationToken);
        var mapped = mapper.Map<ShoppingBasket>(request.Model);

        mapped.Id = request.Id;
        mapped.UserId = request.Model.UserId != default ? request.Model.UserId : entity.UserId;
        mapped.OrderId = request.Model.OrderId != default ? request.Model.OrderId : entity.OrderId;
        mapped.ProductId = request.Model.ProductId != default ? request.Model.ProductId : entity.ProductId;
        mapped.BasketQuantity = request.Model.BasketQuantity != default ? request.Model.BasketQuantity : entity.BasketQuantity;
        mapped.BasketPrice = request.Model.BasketPrice != default ? request.Model.BasketPrice : entity.BasketPrice;
        mapped.BasketStatus = request.Model.BasketStatus;


        unitOfWork.ShoppingBasketRepository.Update(mapped);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        unitOfWork.ShoppingBasketRepository.Delete(request.Id);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }
}
