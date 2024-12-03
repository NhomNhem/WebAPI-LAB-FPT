using Demo19305.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Demo19305.AppDataContext;

// thực hiện kết nối project với database
public class AppDataContext : DbContext
{
    private DbSettings _dbSettings;
    
    public AppDataContext(IOptions<DbSettings> dbSettings)
    {
        _dbSettings = dbSettings.Value;
    }
    
    // DbSet này sẽ map với bảng Accounts trong database
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Character> Characters { get; set; }
    
    // thực hiện cấu hình kết nối với database
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_dbSettings.ConnectionString);
    }
    
    // thực hiện cấu hình các quy tắc với các bảng trong database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .ToTable("accounts") // tên bảng trong db
            .HasKey(k => k.Id);

        modelBuilder.Entity<Character>()
                    .ToTable("characters") // tên bảng trong db
                    .HasKey(k => k.id);


    }
}