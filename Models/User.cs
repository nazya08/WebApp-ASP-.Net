using System;

namespace WebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Second_Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Ролі користувача
        public UserRole Role { get; set; } = UserRole.DefaultUser; // За замовчуванням "DefaultUser"
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    // Enum для ролей
    public enum UserRole
    {
        DefaultUser, // Звичайний користувач
        Admin,       // Адміністратор
        Employee     // Співробітник
    }
}
