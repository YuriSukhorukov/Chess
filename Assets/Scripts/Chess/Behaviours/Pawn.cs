using System;
using Assets.Scripts.Chess.Entities;
using Assets.Scripts.Chess.Interfaces;
using Assets.Scripts.Chess.Values;
using Chess.Interfaces;

namespace Assets.Scripts.Chess.Behaviours
{
    public class Pawn : FigureBase
    {
        private IBoard _board;
        private bool _isFirstStep = true;

        public override void GetAvalableCellsForMove(IBoard board)
        {
            if (this._board == null)
                this._board = board;
            
            AvalableCellsForMove.Clear();

            switch (FigureColor)
            {
                case FigureColor.WHITE:
                    MoveTo(0, _isFirstStep ? 2 : 1);
                    MoveTo(0, 1);
                    break;
                case FigureColor.BLACK:
                    MoveTo(0, _isFirstStep ? -2 : -1);
                    MoveTo(0, -1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            MoveTo(1, -1);
            MoveTo(-1, 1);
            MoveTo(1, 1);
            MoveTo(-1, -1);
        }
        
        private void MoveTo(int i = 0, int j = 0)
        {
            _isFirstStep = false;

            if (InCell.I + i >= _board.Cells.GetLength(0) || InCell.I + i < 0) return;
            if (InCell.J + j >= _board.Cells.GetLength(1) || InCell.J + j < 0) return;
                
            if (i > 0 && j > 0 || i > 0 && j < 0 || i < 0 && j < 0 || i < 0 && j > 0)
            {
                if (!_board.Cells[InCell.I + i, InCell.J + j].IsFree())
                    AvalableCellsForMove.Add(_board.Cells[InCell.I + i, InCell.J + j]);
            }
            else
                if (_board.Cells[InCell.I + i, InCell.J + j].IsFree())
                    AvalableCellsForMove.Add(_board.Cells[InCell.I + i, InCell.J + j]);
        }
    }
}
