using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.Models
{
    public class FindRequest
    {
        [Required]
        [Display(Name ="User Name")]
        public string Username { get; set; }
    }
}
