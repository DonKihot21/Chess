using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(Color _color)
        {
            type = PieceType.Queen;
            color = _color;
        }

        public override bool laMove(Move move)
        {
            if (Movement.DiagonalMove(move.fCell, move.tCell)) return true;
            if (Movement.HorizontalMove(move.fCell, move.tCell)) return true;
            if (Movement.VerticalMove(move.fCell, move.tCell)) return true;
            return false;
        }

       
    }
}
