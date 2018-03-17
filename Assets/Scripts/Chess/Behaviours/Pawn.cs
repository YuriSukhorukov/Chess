using System;
using Assets.Scripts.Chess.Entities;
using Assets.Scripts.Chess.Interfaces;
using Assets.Scripts.Chess.Values;
using Chess.Interfaces;

namespace Assets.Scripts.Chess.Behaviours
{
    public class Pawn : FigureBase
    {
        private bool _isFirstStep = true;

        public override void GetAvalableCellsForMove(IBoard board)
        {
            AvalableCellsForMove.Clear();

            const int i = 1;

            switch (figureColor)
            {
                case FigureColor.WHITE:
                    if (InCell.J + i < board.Cells.GetLength(1))
                        if (board.Cells[InCell.I, InCell.J + i].IsFree())
                            AvalableCellsForMove.Add(board.Cells[InCell.I, InCell.J + i]);

                    if (_isFirstStep)
                        if (InCell.J + 2 < board.Cells.GetLength(1))
                            if (board.Cells[InCell.I, InCell.J + 1].IsFree())
                                AvalableCellsForMove.Add(board.Cells[InCell.I, InCell.J + 2]);

                    if (InCell.I + i < board.Cells.GetLength(0) && InCell.J + i < board.Cells.GetLength(1))
                        if (!board.Cells[InCell.I + i, InCell.J + i].IsFree())
                            AvalableCellsForMove.Add(board.Cells[InCell.I + i, InCell.J + i]);
                    if (InCell.I - i >= 0 && InCell.J + i < board.Cells.GetLength(1))
                        if (!board.Cells[InCell.I - i, InCell.J + i].IsFree())
                            AvalableCellsForMove.Add(board.Cells[InCell.I - i, InCell.J + i]);
                    if (InCell.I - i >= 0 && InCell.J - i >= 0)
                        if (!board.Cells[InCell.I - i, InCell.J - i].IsFree())
                            AvalableCellsForMove.Add(board.Cells[InCell.I - i, InCell.J - i]);
                    if (InCell.I + i < board.Cells.GetLength(0) && InCell.J - i >= 0)
                        if (!board.Cells[InCell.I + i, InCell.J - i].IsFree())
                            AvalableCellsForMove.Add(board.Cells[InCell.I + i, InCell.J - i]);
                    break;
                case FigureColor.BLACK:
                    if (InCell.J - i >= 0)
                        if (board.Cells[InCell.I, InCell.J - i].IsFree())
                            AvalableCellsForMove.Add(board.Cells[InCell.I, InCell.J - i]);

                    if (_isFirstStep)
                        if (InCell.J - 2 >= 0)
                            if (board.Cells[InCell.I, InCell.J - 1].IsFree())
                                AvalableCellsForMove.Add(board.Cells[InCell.I, InCell.J - 2]);

                    if (InCell.I + i < board.Cells.GetLength(0) && InCell.J + i < board.Cells.GetLength(1))
                        if (!board.Cells[InCell.I + i, InCell.J + i].IsFree())
                            AvalableCellsForMove.Add(board.Cells[InCell.I + i, InCell.J + i]);
                    if (InCell.I - i >= 0 && InCell.J + i < board.Cells.GetLength(1))
                        if (!board.Cells[InCell.I - i, InCell.J + i].IsFree())
                            AvalableCellsForMove.Add(board.Cells[InCell.I - i, InCell.J + i]);
                    if (InCell.I - i >= 0 && InCell.J - i >= 0)
                        if (!board.Cells[InCell.I - i, InCell.J - i].IsFree())
                            AvalableCellsForMove.Add(board.Cells[InCell.I - i, InCell.J - i]);
                    if (InCell.I + i < board.Cells.GetLength(0) && InCell.J - i >= 0)
                        if (!board.Cells[InCell.I + i, InCell.J - i].IsFree())
                            AvalableCellsForMove.Add(board.Cells[InCell.I + i, InCell.J - i]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _isFirstStep = false;
        }
    }
}
