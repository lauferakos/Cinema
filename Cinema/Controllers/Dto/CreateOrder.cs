using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers.Dto
{
    public class CreateOrder
    {
        [Required]
        public int ProjectionId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int ReservedSeats { get; set; }
        [Required]
        public int ViewerId { get; set; }
    }
}
