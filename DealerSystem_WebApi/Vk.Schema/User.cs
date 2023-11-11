using BaseLayer;

namespace SchemaLayer;


public class UserRequest : BaseModel
{
    public int UserNumber { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public string UserRole { get; set; }
    public double UserBalance { get; set; }
    public int UserProfitMargin { get; set; }
}

public class UserUpdatedRequest
{
    public int UserNumber { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public string UserRole { get; set; }
    public double UserBalance { get; set; }
    public int UserProfitMargin { get; set; }
}


public class UserResponse : BaseModel
{
    public int UserNumber { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public int UserPasswordRetryCount { get; set; }
    public string UserRole { get; set; }
    public double UserBalance { get; set; }
    public int UserProfitMargin { get; set; }

    public virtual List<CustomerAddressResponse> Addresses { get; set; }
    public virtual List<CustomerOrderResponse> Orders { get; set; }
}
