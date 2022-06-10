using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(Color _color)
        {
            type = PieceType.Rook;
            color = _color;
        }

        public override bool laMove(Move move)
        {

            if (Movement.HorizontalMove(move.fCell, move.tCell)) return true;
            if (Movement.VerticalMove(move.fCell, move.tCell)) return true;
            return false;
        }

       
    }
}
