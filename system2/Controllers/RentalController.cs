using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using system2.Data;
using system2.Models;

namespace system2.Controllers
{
    public class RentalController : Controller
    {

        private readonly ApplicationDbContext db;


        public RentalController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Models.RentalModel> obj = db.Car;

            if (obj == null )
            {
                return NotFound("No objects where found");
            }

            return View(obj);
        }
    }
}
