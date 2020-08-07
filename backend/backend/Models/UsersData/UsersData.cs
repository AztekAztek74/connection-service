using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.UsersData
{
    public class UsersData
    {
        [Key]
        [Required]
        public string Address { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [Phone]
        public int Phone { get; set; }
        [Phone]
        public int AdditionalPhone { get; set; }
        [Required]
        public string HandlingReason { get; set; }
        public string Coment { get; set; }
        [Required]
        public string SelectedTariffs { get; set; }
        
    }
}
