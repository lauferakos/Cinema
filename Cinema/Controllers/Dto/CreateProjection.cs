using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers.Dto
{
    public class CreateProjection
    {
    
        public int Id { get; set; }
        [Required]
        public int FilmId { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public DateTime Start { get; set; }
    }
}
