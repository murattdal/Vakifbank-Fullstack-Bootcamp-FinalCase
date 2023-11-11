namespace SchemaLayer;

public class CustomerAddressRequest
{
    public int UserId { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public int PostalCode { get; set; }
}

public class CustomerAddressUpdatedRequest
{
    public int UserId { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public int PostalCode { get; set; }
}



public class CustomerAddressResponse
{
    public int UserId { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public int PostalCode { get; set; }
}