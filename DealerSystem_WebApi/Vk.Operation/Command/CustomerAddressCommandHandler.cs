using AutoMapper;
using BaseLayer.Response;
using DataLayer.Model;
using DataLayer.Uow;
using MediatR;
using SchemaLayer;

namespace OperationLayer.Command;

public class CustomerAddressCommandHandler :
    IRequestHandler<CreateAddressCommand, ApiResponse<CustomerAddressResponse>>,
    IRequestHandler<UpdateAddressCommand, ApiResponse>,
    IRequestHandler<DeleteAddressCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CustomerAddressCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<CustomerAddressResponse>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<CustomerAddress>(request.Model);

        unitOfWork.CustomerAddressRepository.Insert(mapped); 
        unitOfWork.CompleteTransaction();
        var response = mapper.Map<CustomerAddressResponse>(mapped);
        return new ApiResponse<CustomerAddressResponse>(response);
    }


    public async Task<ApiResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        CustomerAddress entity = await unitOfWork.CustomerAddressRepository.GetByIdAsync(request.Id, cancellationToken);
        var mapped = mapper.Map<CustomerAddress>(request.Model);

        mapped.Id = request.Id;
        mapped.UserId = request.Model.UserId != default ? request.Model.UserId : entity.UserId;
        mapped.AddressLine1 = request.Model.AddressLine1 != "string" ? request.Model.AddressLine1 : entity.AddressLine1;
        mapped.AddressLine2 = request.Model.AddressLine2 != "string" ? request.Model.AddressLine2 : entity.AddressLine2;
        mapped.City = request.Model.City != "string" ? request.Model.City : entity.City;
        mapped.County = request.Model.County != "string" ? request.Model.County : entity.County;
        mapped.PostalCode = request.Model.PostalCode != default ? request.Model.PostalCode : entity.PostalCode;

        unitOfWork.CustomerAddressRepository.Update(mapped);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        unitOfWork.CustomerAddressRepository.Delete(request.Id);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }
}
