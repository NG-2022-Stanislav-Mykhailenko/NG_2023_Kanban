using NG_2023_Kanban.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NG_2023_Kanban.DataLayer.EntityConfiguration
{
    public class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}
