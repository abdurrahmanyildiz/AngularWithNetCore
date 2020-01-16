using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWithNetCore.Models
{
    public class ModelBase
    {
        [Key]
        [Required]
        public long Id { get; set; }
        
        public DateTime CreateDate { get; set; }

        [Required]
        public string OperatorName { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
