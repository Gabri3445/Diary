using Diary.App.Models;
using Microsoft.EntityFrameworkCore;

namespace Diary.App.Databases;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<DiaryPage> DiaryPages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.db");
    }
}