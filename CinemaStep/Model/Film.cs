using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaStep.Model
{
    public class Film:Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double Imdb { get; set; }
        public string ImagePath { get; set; }
        public List<string> Time { get; set; }
    }
}
