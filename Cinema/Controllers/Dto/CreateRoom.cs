using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Controllers.Dto
{
    public class CreateRoom
    {
        [Required]
        public int Capacity { get; set; }
       
    }
}
