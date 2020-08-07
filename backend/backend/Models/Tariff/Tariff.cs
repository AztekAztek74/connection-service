using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.Tariff
{
    public class Tariff
    {
        [Key]
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string ServiceName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public int ServicePrice { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 50)]
        public string ServiceDescription { get; set; }
        [Required]
        public string AccessibleCities { get; set; }

    }
}
