using NG_2023_Kanban.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NG_2023_Kanban.EntityConfiguration
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(100);

            builder.Property(x => x.Column).IsRequired();
            builder.Property(x => x.Column).HasMaxLength(100);

            builder
                .HasOne(x => x.Board)
                .WithMany(x => x.Cards)
                .HasForeignKey(x => x.BoardId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
