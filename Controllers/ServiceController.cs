using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllServices()
        {
            var services = _context.Services.ToList();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null) return NotFound("Service not found");
            return Ok(service);
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetService), new { id = service.Id }, service);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, Service updatedService)
        {
            var service = _context.Services.Find(id);
            if (service == null) return NotFound("Service not found");

            service.Name = updatedService.Name;
            service.Description = updatedService.Description;
            service.Price = updatedService.Price;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null) return NotFound("Service not found");

            _context.Services.Remove(service);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
