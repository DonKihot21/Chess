using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public abstract class Piece
    {
        public PieceType type { get; set; }
        public Color color { get; set; }

        public abstract bool laMove(Move move);
    }
    public enum PieceType
    {
        Pawn,
        Rook,
        Knight,
        Bishop,
        Queen,
        King

    }
    public enum Color
    {
        White,
        Black
    }
    
}
