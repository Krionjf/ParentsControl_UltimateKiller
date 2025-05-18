using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PC_UK_DatabaseDLL
{
    public class DB_Context : DbContext // контроль зв'язку з БД
    {

        public DbSet<Programs> Programs { get; set; } // створення таблиці в БД

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Перевизначає EF бібліотеку щоб вручну налаштувати зв'язок з БД
        {
            optionsBuilder.UseSqlite("Data Source=Programs.db"); // Вказує яку БД створювати та використовувати
        }
    }

    [Table(nameof(DB_Context.Programs))]
    public class Programs // Скелет БД
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;

    }

    public class DB_Tinkering
    {

        const string empty_string = ""; // константа замість string.Emtpy бо чогось в деяких моментах вона не працює

        public List<Programs> DB_GetAllData() // Отримати всю БД як ліст
        {
            using var db = new DB_Context();
            db.Database.EnsureCreated();
            return db.Programs.ToList();
        }

        public bool DB_AddData(string name, string path) // Додати данні
        {

            using var db = new DB_Context();

            db.Database.EnsureCreated(); // Перевіряє чи створена БД, якщо ні то створює

            if (DB_FindData(name, path).Any()) // Перевіряє чи немає такої ж програми або шляху
            {
                return false;
            }
            else
            {
                var data = new Programs { Name = name, Path = path };  // Створює данні якщо такої програми не знайшлося і повертає тру
                db.Programs.Add(data);
                db.SaveChanges();
                return true;
            }

        }

        public List<Programs> DB_FindData(string name = empty_string, string path = empty_string) // Знайти данні
        {
            using var db = new DB_Context();

            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(path))
            {
                return new List<Programs>();  //повертає порожній список у разі пустих значень  
            }
            else
            {
                var query = db.Programs.AsQueryable();

                if (!string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(path)) // Якщо шлях не вказане то шукає ім'я
                {
                    query = query.Where(p => p.Name == name);
                }
                else if (string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(path)) // Тут навпаки
                {
                    query = query.Where(p => p.Path == path);
                }
                else
                {
                    query = query.Where(p => p.Name == name || p.Path == path); // А тут якщо обидва вказані то шукає обидва
                }

                return query.ToList();
            }
        }
        public bool DB_DeleteData(string name, string path) // Видалити данні
        {

            using var db = new DB_Context();
            db.Database.EnsureCreated(); // Перевіряє чи створена БД, якщо ні то створює
            if (DB_FindData(name, path).Any()) // Якщо такі програми знайдені то видаляє їх та повертає тру
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
