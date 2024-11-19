using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            var appointments = _context.Appointments
                .Include(a => a.User)
                .Include(a => a.Service)
                .ToList();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public IActionResult GetAppointment(int id)
        {
            var appointment = _context.Appointments
                .Include(a => a.User)
                .Include(a => a.Service)
                .FirstOrDefault(a => a.Id == id);
            if (appointment == null) return NotFound("Appointment not found");
            return Ok(appointment);
        }

        [HttpPost]
        public IActionResult CreateAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, Appointment updatedAppointment)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null) return NotFound("Appointment not found");

            appointment.UserId = updatedAppointment.UserId;
            appointment.ServiceId = updatedAppointment.ServiceId;
            appointment.Description = updatedAppointment.Description;
            appointment.AppointmentDate = updatedAppointment.AppointmentDate;
            appointment.Status = updatedAppointment.Status;
            appointment.Is_Active = updatedAppointment.Is_Active;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null) return NotFound("Appointment not found");

            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
