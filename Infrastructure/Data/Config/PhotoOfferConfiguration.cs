using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    public class PhotoOfferConfiguration : IEntityTypeConfiguration<PhotoOffer>
    {
        public void Configure(EntityTypeBuilder<PhotoOffer> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.Duration).IsRequired();
            builder.Property(p => p.NumberOfPhotos).IsRequired();
            builder.Property(p => p.IsAlbumIncluded).IsRequired();
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(c => c.PhotoOfferCategory).WithMany().HasForeignKey(c => c.PhotoOfferCategoryId);
        }
    }
}
