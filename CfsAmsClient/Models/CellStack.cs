using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CfsAmsClient.Models
{
    class CellStack
    {
        public CellStack()
        {
            for (int i = 0; i < NumberOfCells; i++)
            {
                Cells.Add(new Cell());
            }
        }
        public const int NumberOfCells = 23;
        public List<Cell> Cells { get; private set; } = new List<Cell>(NumberOfCells);
        public string Name { get; set; }
        //public Cell[] Cells { get; private set; } = new Cell[NumberOfCells];
    }
}
