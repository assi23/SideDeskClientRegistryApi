using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SideDesk.ClientRegister.Application.Entities;

namespace SideDesk.ClientRegister.Infrastructure.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client");

            builder.HasKey(client => client.Id);

            builder.Property(client => client.Id).HasColumnName("id").HasColumnType("int4");
            builder.Property(client => client.Name).HasColumnName("name").HasColumnType("varchar").HasMaxLength(150);
            builder.Property(client => client.Document).HasColumnName("document").HasColumnType("varchar").HasMaxLength(18);
        }
    }
}
