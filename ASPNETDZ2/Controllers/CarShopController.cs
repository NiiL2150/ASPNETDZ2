using ASPNETDZ2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETDZ2.Controllers
{
    public class CarShopController : Controller
    {
        private readonly ASPNETCarsContext _context;
        public CarShopController(ASPNETCarsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Cars()
        {
            return View(await _context.Cars.ToListAsync<Car>());
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCar(Car car, IFormFile imgfile)
        {
            car.CarImage = await imgfile.GetBytes();
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return RedirectToAction("Cars");
        }

        [HttpGet]
        public async Task<IActionResult> Car(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(car=>car.Id == id);
            if(car == null)
            {
                return RedirectToAction("Cars");
            }
            return View(car);
        }
    }
}
