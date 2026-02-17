using CarShopFinal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShopFinal.Persistance.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Brand)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.Model)
            .IsRequired()
            .HasMaxLength(100);

        

    }
}
