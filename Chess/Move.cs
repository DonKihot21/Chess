using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Move
    {
        public Piece piece { get; set; }
        public Cell fCell { get; set; }
        public Cell tCell { get; set; }
    }
}
