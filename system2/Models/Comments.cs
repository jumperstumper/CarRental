using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace system2.Models
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Comment")]
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }
}
