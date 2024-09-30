using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdminService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdminService.DAL.EF
{
    public class ClientDataConfig : IEntityTypeConfiguration<ClientData>
    {
        public void Configure(EntityTypeBuilder<ClientData> builder)
        {
            builder.ToTable("clientsdata").HasKey(c => c.id);
            builder.HasOne(cd => cd.clientOrder).WithOne(co => co.clientData).HasForeignKey<ClientOrder>(co => co.clientDataId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable(cd => cd.HasCheckConstraint("age", "age > 18"));
        }
    }
}
