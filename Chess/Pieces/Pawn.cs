using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Color _color)
        {
            type = PieceType.Pawn;
            color = _color;
        }
     
        public override bool laMove(Move move)
        {
            if (Math.Abs(move.tCell.xLocation - move.fCell.xLocation) == 1 && move.tCell.yLocation == move.fCell.yLocation)
                return true;

            return false;
        }
    }
}
