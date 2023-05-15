using NG_2023_Kanban.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NG_2023_Kanban.DataLayer.EntityConfiguration
{
    public class ColumnConfiguration : IEntityTypeConfiguration<Column>
    {
        public void Configure(EntityTypeBuilder<Column> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.Property(x => x.Board).IsRequired();
            builder.Property(x => x.Board).HasMaxLength(100);

            builder
                .HasOne(x => x.Board)
                .WithMany(x => x.Columns)
                .HasForeignKey(x => x.BoardId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
