using MyFirstEntity.Data;

namespace MyFirstEntity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                context.SeedData();
            }

        }
    }
}