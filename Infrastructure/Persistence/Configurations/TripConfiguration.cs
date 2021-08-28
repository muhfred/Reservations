using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.Property(t => t.TripName).HasMaxLength(64).IsRequired();
            builder.Property(t => t.CityName).HasMaxLength(35).IsRequired();
            builder.Property(t => t.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(t => t.ImageUrl).IsRequired();
            builder.Property(t => t.Content).IsRequired();
        }
    }
}
