﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using BaseLayer;

namespace DataLayer.Model;

[Table("ShoppingBasket", Schema = "dbo")]
public class ShoppingBasket:BaseModel
{
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public int ProductId { get; set; }
    public virtual Product Product{ get; set; }

    public int? OrderId { get; set; }
    public virtual CustomerOrder Order { get; set; }

    public int BasketQuantity { get; set; }
    public double BasketPrice { get; set; }
    public bool BasketStatus { get; set; }
}

public class ShoppingBasketConfiguration : IEntityTypeConfiguration<ShoppingBasket>
{
    public void Configure(EntityTypeBuilder<ShoppingBasket> builder)
    {

        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UserId).IsRequired(true);
        builder.Property(x => x.OrderId).IsRequired(false);
        builder.Property(x => x.ProductId).IsRequired(true);
        builder.Property(x => x.BasketQuantity).IsRequired();
        builder.Property(x => x.BasketPrice).IsRequired();
        builder.Property(x => x.BasketStatus).IsRequired();
        

        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.OrderId);
        builder.HasIndex(x => x.ProductId);
    }
}
