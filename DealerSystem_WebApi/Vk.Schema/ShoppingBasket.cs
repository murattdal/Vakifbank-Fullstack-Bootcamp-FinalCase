using BaseLayer;

namespace SchemaLayer;

public class ShoppingBasketRequest
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int BasketQuantity { get; set; }
    public double BasketPrice { get; set; }
    public bool BasketStatus { get; set; }
}

public class ShoppingBasketUpdatedRequest
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int BasketQuantity { get; set; }
    public double BasketPrice { get; set; }
    public bool BasketStatus { get; set; }
}



public class ShoppingBasketResponse : BaseModel
{

    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int BasketQuantity { get; set; }
    public double BasketPrice { get; set; }
    public bool BasketStatus { get; set; }
}