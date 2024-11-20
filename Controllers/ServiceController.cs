using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("services")]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Отримуємо всі сервіси з бази даних
            var services = await _context.Services.ToListAsync();

            // Повертаємо представлення та передаємо список сервісів
            return View("~/Views/Service/Index.cshtml", services);
        }

        // Детальний перегляд сервісу
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            // Отримуємо сервіс за ID з бази даних
            var service = await _context.Services
                .FirstOrDefaultAsync(s => s.Id == id);

            if (service == null)
            {
                return NotFound(); // Якщо сервіс не знайдений
            }

            // Повертаємо представлення для детального перегляду
            return View("~/Views/Service/Detail.cshtml", service);
        }
    }
}
