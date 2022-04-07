using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Asteroids
    {
        public string Name { get; set; }
        public string Planet { get; set; }
        public double Diameter { get; set; }
        public string Velocity { get; set; }        
        public DateTime Date { get; set; }
    }
}
