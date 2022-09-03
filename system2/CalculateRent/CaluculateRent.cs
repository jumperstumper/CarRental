using System.Linq;
using system2.Data;

namespace system2.RentalModel
{
    public class CaluculateRent
    {

        private readonly ApplicationDbContext db;

        public CaluculateRent(ApplicationDbContext db)
        {
            this.db = db;
        }


        public int Calculate(int id)
        {
            var obj = db.Car.Where(x => x.Id == id).FirstOrDefault();


            var price = obj.DailyPrice;

            var days = obj.RentalDays;

            var total = price * days;

            return total;

        }


    }
}
