using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using BaseLayer;

namespace DataLayer.Model;

[Table("CustomerAddress", Schema = "dbo")]
public class CustomerAddress : BaseModel
{
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public int PostalCode { get; set; }
}




public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
{
    public void Configure(EntityTypeBuilder<CustomerAddress> builder)
    {

        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UserId).IsRequired(true);
        builder.Property(x => x.AddressLine1).HasMaxLength(100).IsRequired();
        builder.Property(x => x.AddressLine2).HasMaxLength(100);
        builder.Property(x => x.City).HasMaxLength(50).IsRequired();
        builder.Property(x => x.County).HasMaxLength(50).IsRequired();
        builder.Property(x => x.PostalCode).HasMaxLength(20).IsRequired();

        builder.HasIndex(x => x.UserId);
    }
}