using BaseLayer;

namespace SchemaLayer;

public class ProductRequest
{
    public string ProductName { get; set; }
    public string ProductImage { get; set; }
    public int ProductQuantity { get; set; }
    public double ProductPrice { get; set; }    
    public string ProductInformation { get; set; }
}

public class ProductUpdatedRequest
{
    public string ProductName { get; set; }
    public string ProductImage { get; set; }
    public int ProductQuantity { get; set; }
    public double ProductPrice { get; set; }
    public string ProductInformation { get; set; }
}

public class ProductResponse: BaseModel
{
    public string ProductName { get; set; }
    public string ProductImage { get; set; }
    public int ProductQuantity { get; set; }
    public double ProductPrice { get; set; }
    public string ProductInformation { get; set; }
}
