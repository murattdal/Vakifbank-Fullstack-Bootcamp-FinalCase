using AutoMapper;
using DataLayer.Model;
using SchemaLayer;

namespace OperationLayer.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<ProductRequest, Product>();
        CreateMap<ProductUpdatedRequest, Product>();
        CreateMap<Product, ProductResponse>();

        CreateMap<CustomerAddressRequest, CustomerAddress>();
        CreateMap<CustomerAddressUpdatedRequest, CustomerAddress>();
        CreateMap<CustomerAddress, CustomerAddressResponse>();

        CreateMap<UserRequest, User>();
        CreateMap<UserUpdatedRequest, User>();
        CreateMap<User, UserResponse>();

        CreateMap<CustomerOrderRequest, CustomerOrder>();
        CreateMap<CustomerOrderUpdatedRequest, CustomerOrder>();
        CreateMap<CustomerOrder, CustomerOrderResponse>();

        CreateMap<ShoppingBasketRequest, ShoppingBasket>();
        CreateMap<ShoppingBasketUpdatedRequest, ShoppingBasket>();
        CreateMap<ShoppingBasket, ShoppingBasketResponse>();
    }
}