namespace NG_2023_Kanban.DataLayer.DbStartup
{
    public class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
