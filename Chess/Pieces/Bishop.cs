using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Color _color)
        {
            type = PieceType.Bishop;
            color = _color;
        }

        public override bool laMove(Move move)
        {
            if(Movement.DiagonalMove(move.fCell, move.tCell)) return true;
            return false;
        }
        public bool isBlocked(Move move)
        {   
            return false;
        }


    }
}
