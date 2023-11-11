using BaseLayer;

namespace SchemaLayer;

public class CustomerOrderRequest : BaseModel
{
    public int UserId { get; set; }
    public string OrderStatus { get; set; }
    public string OrderPaymentMethod { get; set; }
    public double OrderAmount { get; set; }

}

public class CustomerOrderUpdatedRequest
{
    public int UserId { get; set; }
    public string OrderStatus { get; set; }
    public string OrderPaymentMethod { get; set; }
    public double OrderAmount { get; set; }

}

public class CustomerOrderResponse : BaseModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string OrderStatus { get; set; }
    public string OrderPaymentMethod { get; set; }
    public double OrderAmount { get; set; }

    public DateTime InsertDate { get; set; }
}
