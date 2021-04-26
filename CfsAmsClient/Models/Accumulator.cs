using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfsAmsClient.Models
{
    class Accumulator
    {
        //public const int NumberOfCellStacks = 6;
        //public CellStack[] CellStacks { get; private set; } = new CellStack[NumberOfCellStacks];
        public List<CellStack> CellStacks { get; private set; } = new List<CellStack>()
        {
            new CellStack{Name = "Segment 1" },
            new CellStack{Name = "Segment 2" },
            new CellStack{Name = "Segment 3" },
            new CellStack{Name = "Segment 4" },
            new CellStack{Name = "Segment 5" },
            new CellStack{Name = "Segment 6" },
        };
        public double IVT1 { get; set; }
        public double IVT2 { get; set; }
        public double IVT3 { get; set; }
        public double Current { get; set; }
    }
}
