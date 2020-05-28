using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers.Dto
{
    public class CreateViewer
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string PassWord { get; set; }
    }
}
