using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers.Dto
{
    public class CreateFilm
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}
