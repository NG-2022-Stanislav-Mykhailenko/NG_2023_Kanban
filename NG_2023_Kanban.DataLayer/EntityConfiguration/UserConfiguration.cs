using NG_2023_Kanban.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NG_2023_Kanban.DataLayer.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.FullName).IsRequired();
            builder.Property(x => x.FullName).HasMaxLength(100);

            builder.HasIndex(x => x.Username).IsUnique(true);
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.Password).IsRequired();

            builder
                .HasMany(x => x.Boards)
                .WithMany(x => x.Users);

            builder
                .HasMany(x => x.Roles)
                .WithMany(x => x.Members);
        }
    }
}
