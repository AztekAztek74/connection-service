using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models.EarlyCompletion
{
    public class EarlyCompletion
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EarlyCompletionId { get; set; }
        
        [Required]
        [Phone]
        public int EarlyCompletionPhone { get; set; }
        public string EarlyCompletionCause { get; set; }
        public string OtherInformation { get; set; }
    }
}
