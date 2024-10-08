﻿using AdminService.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace AdminService.DAL.EF
{
    public class ProductOrderConfig : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.ToTable("productorders").HasKey(c => c.id);
            builder.HasIndex(c => c.guid).IsUnique();
        }
    }
}