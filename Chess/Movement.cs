using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public static class Movement
    {
        public static bool HorizontalMove(Cell fCell, Cell tCell)
        {
            for (int i = 0; i < 8; i++)
            {   
                if(tCell.xLocation == fCell.xLocation && tCell.yLocation - i < fCell.yLocation || tCell.xLocation == fCell.xLocation && tCell.yLocation + i > fCell.yLocation)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool VerticalMove(Cell fCell, Cell tCell)
        {
            for (int i = 0; i < 8; i++)
            {
                if (tCell.yLocation == fCell.yLocation) return true;
            }
            return false;
        }
        public static bool DiagonalMove(Cell fCell, Cell tCell)
        {
            for (int i = 0; i < 8; i++)
            {
                if (tCell.xLocation == fCell.xLocation + i && tCell.yLocation == fCell.yLocation + i)
                    return true;
                if (tCell.xLocation == fCell.xLocation - i && tCell.yLocation == fCell.yLocation + i)
                    return true;
                if (tCell.xLocation == fCell.xLocation - i && tCell.yLocation == fCell.yLocation - i)
                    return true;
                if (tCell.xLocation == fCell.xLocation + i && tCell.yLocation == fCell.yLocation - i)
                    return true;
            }
            return false;
        }

    }
}
