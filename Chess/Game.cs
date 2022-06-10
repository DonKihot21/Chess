using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Pieces;

namespace Chess
{
    public class Game
    {
        public Cell[][] board { get; set; }
        public List<Move> legalMoves { get; set; } = new List<Move>();
        public Game()
        {
            board = new Cell[][]
            {
                new Cell[]
                {
                    new Cell(new Rook(Color.Black)),
                    new Cell(new Knight(Color.Black)),
                    new Cell(new Bishop(Color.Black)),
                    new Cell(new Queen(Color.Black)),
                    new Cell(new King(Color.Black)),
                    new Cell(new Bishop(Color.Black)),
                    new Cell(new Knight(Color.Black)),
                    new Cell(new Rook(Color.Black))
                },

                GenerateCells(GeneratePawns(Color.Black)),

                new Cell[]{new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null)},
                new Cell[]{new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null)},
                new Cell[]{new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null)},
                new Cell[]{new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null), new Cell(null)},
                GenerateCells(GeneratePawns(Color.White)),

                new Cell[]
                {
                    new Cell(new Rook(Color.White)),
                    new Cell(new Knight(Color.White)),
                    new Cell(new Bishop(Color.White)),
                    new Cell(new Queen(Color.White)),
                    new Cell(new King(Color.White)),
                    new Cell(new Bishop(Color.White)),
                    new Cell(new Knight(Color.White)),
                    new Cell(new Rook(Color.White))
                }
            };
            SetPositions();
            callLegalMoves();
            Display();
            while (true)
            {
                string[] fC;
                string[] tC;
                do
                {
                    Console.Write("White Player FROM: ");
                    fC = Console.ReadLine().Split(' ').ToArray();
                    Console.Write("TO: ");
                    tC = Console.ReadLine().Split(' ').ToArray();
                } while (board[int.Parse(fC[0])][int.Parse(fC[1])].piece.color != Color.White);
                PerformMove(new Move()
                {
                    fCell = board[int.Parse(fC[0])][int.Parse(fC[1])
                ],
                    tCell = board[int.Parse(tC[0])][int.Parse(tC[1])],
                    piece = board[int.Parse(fC[0])][int.Parse(fC[1])].piece
                });
                Display();
                string[] fC2;
                string[] tC2;
                do
                {
                    Console.Write("Black Player FROM: ");
                    fC2 = Console.ReadLine().Split(' ').ToArray();
                    Console.Write("TO: ");
                    tC2 = Console.ReadLine().Split(' ').ToArray();
                } while (board[int.Parse(fC2[0])][int.Parse(fC2[1])].piece.color != Color.Black);
                PerformMove(new Move()
                {
                    fCell = board[int.Parse(fC2[0])][int.Parse(fC2[1])
                    ],
                    tCell = board[int.Parse(tC2[0])][int.Parse(tC2[1])],
                    piece = board[int.Parse(fC2[0])][int.Parse(fC2[1])].piece
                });
                Display();

            }

        }
        public void callLegalMoves()
        {
            foreach (var cells in board)
            {
                foreach (var cell in cells)
                {
                    try
                    {
                        LegalMoves(cell);
                    }
                    catch { }
                }
            }
        }
        public List<Move> LegalMoves(Cell _cell)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    Move move = new Move()
                    {
                        fCell = _cell,
                        tCell = board[i][j],
                        piece = _cell.piece
                    };
                    if (move.piece.laMove(move))
                        legalMoves.Add(move);
                }
            }
            return new List<Move>();
        }

        public bool IsBlocked(Move move)
        {
            // CHECK IF COLOR OF TO CELL AND FROM CELL IS SAME
            if (board[move.tCell.xLocation][move.tCell.yLocation].piece != null)
                if (board[move.tCell.xLocation][move.tCell.yLocation].piece.color == move.piece.color)
                    return true;
            // CHECK IF THERE IS PIECES IN PATH TO tCell
            if (move.fCell.xLocation > move.tCell.xLocation && move.fCell.yLocation > move.tCell.yLocation)
            {
                for (int i = move.tCell.xLocation + 1; i < move.fCell.xLocation; i++)
                {
                    for (int j = move.tCell.yLocation + 1; j < move.fCell.yLocation; j++)
                        if (board[i][j].piece != null) return true;
                }
            }
            if (move.fCell.xLocation > move.tCell.xLocation && move.fCell.yLocation < move.tCell.yLocation)
            {
                for (int i = move.tCell.xLocation + 1; i < move.fCell.xLocation; i++)
                {
                    for (int j = move.tCell.yLocation - 1; j > move.fCell.yLocation; j--)
                        if (board[i][j].piece != null) return true;
                }
            }
            if (move.fCell.xLocation < move.tCell.xLocation && move.fCell.yLocation > move.tCell.yLocation)
            {
                for (int i = move.tCell.xLocation - 1; i > move.fCell.xLocation; i--)
                {
                    for (int j = move.tCell.yLocation + 1; j < move.fCell.yLocation; j++)
                        if (board[i][j].piece != null) return true;
                }
            }
            if (move.fCell.xLocation < move.tCell.xLocation && move.fCell.yLocation < move.tCell.yLocation)
            {
                for (int i = move.tCell.xLocation - 1; i > move.fCell.xLocation; i--)
                {
                    for (int j = move.tCell.yLocation - 1; j > move.fCell.yLocation; j--)
                        if (board[i][j].piece != null) return true;
                }
            }
            if (move.fCell.xLocation == move.tCell.xLocation && move.fCell.yLocation > move.tCell.yLocation)
            {
                for (int j = move.tCell.yLocation + 1; j < move.fCell.yLocation; j++)
                {
                    if (board[move.fCell.xLocation][j].piece != null) return true;
                }

            }
            if (move.fCell.xLocation == move.tCell.xLocation && move.fCell.yLocation < move.tCell.yLocation)
            {
                for (int j = move.tCell.yLocation - 1; j > move.fCell.yLocation; j--)
                {
                    if (board[move.fCell.xLocation][j].piece != null) return true;
                }

            }
            if (move.fCell.xLocation > move.tCell.xLocation && move.fCell.yLocation == move.tCell.yLocation)
            {
                for (int j = move.tCell.xLocation + 1; j < move.fCell.xLocation; j++)
                {
                    if (board[j][move.fCell.yLocation].piece != null) return true;
                }

            }
            if (move.fCell.xLocation < move.tCell.xLocation && move.fCell.yLocation == move.tCell.yLocation)
            {
                for (int j = move.tCell.xLocation - 1; j > move.fCell.xLocation; j--)
                {
                    if (board[j][move.fCell.yLocation].piece != null) return true;
                }

            }

            return false;
        }
        public void PerformMove(Move move)
        {
            for (int i = 0; i < legalMoves.Count; i++)
            {
                var lm = legalMoves[i];

                if (lm.fCell.xLocation == move.fCell.xLocation && lm.fCell.yLocation == move.fCell.yLocation
                    && lm.tCell.xLocation == move.tCell.xLocation && lm.tCell.yLocation == move.tCell.yLocation)
                {
                    if (IsBlocked(move))
                    {
                        Console.WriteLine("BLOCKED");
                        break;
                    }
                    Console.WriteLine("Move made");
                    board[move.tCell.xLocation][move.tCell.yLocation].piece = move.fCell.piece;
                    board[move.fCell.xLocation][move.fCell.yLocation].piece = null;
                }

            }
            legalMoves = new List<Move>();
            callLegalMoves();
        }
        public Pawn[] GeneratePawns(Color color)
        {
            Pawn[] pawns = new Pawn[8];
            for (int i = 0; i < 8; i++)
            {
                pawns[i] = new Pawn(color);
            }
            return pawns;
        }
        public Cell[] GenerateCells(Piece[] piece)
        {
            Cell[] cells = new Cell[8];
            for (int i = 0; i < 8; i++)
            {
                cells[i] = new Cell(piece[i]);
            }
            return cells;
        }

        public void Display()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i][j].piece == null) Console.Write(" * ");
                    else
                        Console.Write(" " + board[i][j].piece.type.ToString()[0] + "" + board[i][j].piece.color.ToString()[0]);
                }
                Console.WriteLine();
            }
        }
        public void SetPositions()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i][j].xLocation = i;
                    board[i][j].yLocation = j;
                }
            }
        }
    }
}
