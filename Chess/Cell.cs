using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Cell
    {
        public int xLocation { get; set; }
        public int yLocation { get; set; }
#nullable enable
        public Piece? piece { get; set; }


        public Cell(Piece? _piece)
        {
            piece = _piece;
        }
    }
}
