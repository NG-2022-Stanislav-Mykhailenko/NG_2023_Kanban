using NG_2023_Kanban.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NG_2023_Kanban.DataLayer.EntityConfiguration
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

            builder
                .HasOne(x => x.Assigned)
                .WithMany(x => x.CardsAssigned)
                .HasForeignKey(x => x.AssignedId)
                .HasPrincipalKey(x => x.Id);

            builder
                .HasOne(x => x.Column)
                .WithMany(x => x.Cards)
                .HasForeignKey(x => x.ColumnId)
                .HasPrincipalKey(x => x.Id);

            builder
                .HasOne(x => x.Sender)
                .WithMany(x => x.CardsSent)
                .HasForeignKey(x => x.SenderId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
