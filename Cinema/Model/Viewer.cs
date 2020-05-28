using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Viewer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PassWord { get; set; }


        public Viewer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
