using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestAppBank.Models;

namespace WebTestAppBank.Data
{
    internal static class DatabaseBank
    {
        internal static readonly int[] Banknotes = new int[]
        {
            100, 200, 500, 1000, 2000, 5000
        };

        internal static Dictionary<int, Casset[]> Cassets { get; set; } = new Dictionary<int, Casset[]>();
    }
}
