using Assets.Scripts.Chess.Entities;
using Assets.Scripts.Chess.Interfaces;
using Chess.Interfaces;

namespace Assets.Scripts.Chess.Behaviours
{
    public class Knight : FigureBase
    {
        private IBoard _board;
        private bool _isFirstStep = true;
        
        public override void GetAvalableCellsForMove(IBoard board)
        {
            if (this._board == null)
                this._board = board;
            
            if (InCell == null) return;

            AvalableCellsForMove.Clear();
           
            MoveTo(2, 1);
            MoveTo(2, -1);
            MoveTo(-2, 1);
            MoveTo(-2, -1);
            
            MoveTo(1, 2);
            MoveTo(1, -2);
            MoveTo(-1, 2);
            MoveTo(-1, -2);
        }
        
        private void MoveTo(int i = 0, int j = 0)
        {
            _isFirstStep = false;

            if (InCell.I + i >= _board.Cells.GetLength(0) || InCell.I + i < 0) return;
            if (InCell.J + j >= _board.Cells.GetLength(1) || InCell.J + j < 0) return;
                
            AvalableCellsForMove.Add(_board.Cells[InCell.I + i, InCell.J + j]);
        }
    }
}
