using System;
using System.ComponentModel.DataAnnotations;

namespace system2.Models
{
    public class RentalModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public int DailyPrice { get; set; }

        public int RentalDays { get; set; }

        public  DateTime DayOfRent { get; set; }

        public DateTime DayOfReturn { get; set; }


    }
}
