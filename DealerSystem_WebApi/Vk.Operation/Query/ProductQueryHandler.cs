using AutoMapper;
using BaseLayer.Response;
using DataLayer.Model;
using DataLayer.Uow;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchemaLayer;

namespace OperationLayer.Query;

public class ProductQueryHandler :
     IRequestHandler<GetAllProductQuery, ApiResponse<List<ProductResponse>>>,
     IRequestHandler<GetProductByIdQuery, ApiResponse<ProductResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<ApiResponse<List<ProductResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        List<Product> list = unitOfWork.ProductRepository.GetAll();
        List<ProductResponse> mapped = mapper.Map<List<ProductResponse>>(list);
        return new ApiResponse<List<ProductResponse>>(mapped);
    }

    public async Task<ApiResponse<ProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        Product entity = await unitOfWork.ProductRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return new ApiResponse<ProductResponse>("Record not found");
        }

        ProductResponse mapped = mapper.Map<ProductResponse>(entity);
        return new ApiResponse<ProductResponse>(mapped);
    }
}
