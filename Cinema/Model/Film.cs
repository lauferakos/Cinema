using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        public Film(int id, string title, string director, string description, int rating)
        {
            Id = id;
            Title = title;
            Director = director;
            Description = description;
            Rating = rating;
        }

    }
}
