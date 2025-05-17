using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PC_UK_DatabaseDLL
{
    public class DB_Context : DbContext
    {

        public DbSet<Programs> Programs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Programs.db");
        }
    }

    [Table(nameof(DB_Context.Programs))]
    public class Programs
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path {  get; set; } = string.Empty;

    }

    public class DB_Tinkering
    {

        const string empty_string = "";
       public bool DB_AddData(string name, string path)
        {

            using var db = new DB_Context();
            
            db.Database.EnsureCreated();

            if (DB_FindData(name, path).Count > 0)
            {
                return false;
            }
            else
            {
                var data = new Programs { Name = name, Path = path };
                db.Programs.Add(data);
                db.SaveChanges();
                return true;
            }
            
        }

        public List<Programs> DB_FindData(string name = empty_string, string path = empty_string)
        {
            using var db = new DB_Context();
           
            return db.Programs.FromSqlRaw("SELECT * FROM Programs WHERE Name = {0} OR WHERE Path = {1}", name,path).ToList();
            
        }

        public bool DB_DeleteData(string name)
        {

            using var db = new DB_Context();
            db.Database.EnsureCreated();
            if (DB_FindData(name) != null)
            {

                db.Programs.RemoveRange(DB_FindData(name));
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

    }


}
