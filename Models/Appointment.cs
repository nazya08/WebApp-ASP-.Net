namespace WebApp.Models
{
    public enum AppointmentStatus
    {
    Pending,    // Очікує обробки
    Confirmed,  // Підтверджено
    Cancelled   // Скасовано
    }

    public class Appointment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending; // Наприклад: Підтверджено, В обробці, Скасовано
        public bool Is_Active { get; set; }


        // Навігаційні властивості
        public User User { get; set; }
        public Service Service { get; set; }
    }
}
