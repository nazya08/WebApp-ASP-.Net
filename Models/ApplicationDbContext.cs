using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet для кожної моделі
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Налаштування збереження User.Role як рядка
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            // Налаштування збереження Appointment.Status як рядка
            modelBuilder.Entity<Appointment>()
                .Property(a => a.Status)
                .HasConversion<string>();

            // Додаткові налаштування
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique(); // Забезпечення унікальності Email

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.User) // Зв'язок між Appointment і User
                .WithMany()          // Один користувач може мати багато Appointment
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Каскадне видалення

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Service) // Зв'язок між Appointment і Service
                .WithMany()             // Один сервіс може бути в багатьох Appointment
                .HasForeignKey(a => a.ServiceId)
                .OnDelete(DeleteBehavior.Restrict); // Заборона видалення сервісу, якщо він використовується

            base.OnModelCreating(modelBuilder); // Виклик базової реалізації
        }
    }
}
