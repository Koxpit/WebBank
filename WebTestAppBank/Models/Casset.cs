using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTestAppBank.Models
{
    public class Casset
    {
        public int ID { get; set; }
        public Dictionary<int, int> Nominals { get; set; } = new Dictionary<int, int>();
        public bool IsActive { get; set; } = true;
        public int Sum { get; set; } = 0;
    }
}
