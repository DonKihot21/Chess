using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(Color _color)
        {
            type = PieceType.Knight;
            color = _color;
        }

        public override bool laMove(Move move)
        {
            if ((move.tCell.xLocation - 2) == move.fCell.xLocation && Math.Abs((move.tCell.yLocation - move.fCell.yLocation)) == 1)
            {
                return true;
            }
            if (move.tCell.xLocation == 3 || move.tCell.xLocation == 4)
                return true;
            return false;
        }

        
    }
}
