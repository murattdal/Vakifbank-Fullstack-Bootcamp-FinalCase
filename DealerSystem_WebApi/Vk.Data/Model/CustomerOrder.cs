using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using BaseLayer;

namespace DataLayer.Model;

[Table("CustomerOrder", Schema = "dbo")]
public class CustomerOrder : BaseModel
{
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public string OrderStatus { get; set; }
    public string OrderPaymentMethod { get; set; }
    public double OrderAmount { get; set; }

    public virtual List<ShoppingBasket> Baskets { get; set; }


}

public class CustomerOrderConfiguration : IEntityTypeConfiguration<CustomerOrder>
{
    public void Configure(EntityTypeBuilder<CustomerOrder> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UserId).IsRequired(true);
        builder.Property(x => x.OrderStatus).IsRequired();
        builder.Property(x => x.OrderPaymentMethod).IsRequired();
        builder.Property(x => x.OrderAmount).IsRequired();

        builder.HasIndex(x => x.UserId);

        builder.HasMany(x => x.Baskets)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);




    }
}
