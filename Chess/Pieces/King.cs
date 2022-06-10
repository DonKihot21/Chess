using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class King : Piece
    {
        public King(Color _color)
        {
            type = PieceType.King;
            color = _color;
        }

        public override bool laMove(Move move)
        {
            if (move.tCell.xLocation == move.fCell.xLocation && move.tCell.yLocation - 1 == move.fCell.yLocation) return true;
            if (move.tCell.xLocation - 1 == move.fCell.xLocation && move.tCell.yLocation == move.fCell.yLocation) return true;
            if (move.tCell.xLocation - 1 == move.fCell.xLocation && move.tCell.yLocation - 1 == move.fCell.yLocation) return true;
            if (move.tCell.xLocation + 1 == move.fCell.xLocation && move.tCell.yLocation - 1 == move.fCell.yLocation) return true;
            if (move.tCell.xLocation + 1 == move.fCell.xLocation && move.tCell.yLocation + 1 == move.fCell.yLocation) return true;

            return false;
        }

       
    }
}
