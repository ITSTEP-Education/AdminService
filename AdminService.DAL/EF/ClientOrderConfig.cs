using AdminService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminService.DAL.EF
{
    public class ClientOrderConfig : IEntityTypeConfiguration<ClientOrder>
    {
        public void Configure(EntityTypeBuilder<ClientOrder> builder)
        {
            builder.ToTable("clientorders").HasKey(c => c.id);
            builder.Property(co => co.clientDataId).HasColumnName("FK_ClientId");
            builder.HasIndex(co => co.clientDataId).IsUnique().HasDatabaseName("IX_ClientOrder_ClientDataId");
        }
    }
}
