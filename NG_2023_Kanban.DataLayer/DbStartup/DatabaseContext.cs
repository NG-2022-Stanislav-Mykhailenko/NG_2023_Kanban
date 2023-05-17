using NG_2023_Kanban.DataLayer.Entities;
using NG_2023_Kanban.DataLayer.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace NG_2023_Kanban.DataLayer.DbStartup
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BoardConfiguration());
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new ColumnConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
