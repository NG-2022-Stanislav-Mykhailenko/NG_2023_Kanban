using NG_2023_Kanban.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NG_2023_Kanban.DataLayer.EntityConfiguration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Text).HasMaxLength(100);

            builder
                .HasOne(x => x.Sender)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.SenderId)
                .HasPrincipalKey(x => x.Id);

            builder
                .HasOne(x => x.Card)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.CardId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
