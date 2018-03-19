using Assets.Scripts.Chess.Entities;
using Assets.Scripts.Chess.Interfaces;
using Chess.Interfaces;

namespace Assets.Scripts.Chess.Behaviours
{
    public class Queen : FigureBase
    {
        private IBoard _board;
        
        public override void GetAvalableCellsForMove(IBoard board)
        {
            if (this._board == null)
                this._board = board;
            
            if (InCell == null) return;

            AvalableCellsForMove.Clear();

//          Поиск ходов по прямой
            MoveTo(1,0);
            MoveTo(-1,0);
            MoveTo(0,1);
            MoveTo(0,-1);
            
//          Поиск ходов по диагонали
            MoveTo(1,1);
            MoveTo(-1,-1);
            MoveTo(-1,1);
            MoveTo(1,-1);
        }
        
        private void MoveTo(int i, int j)
        {
            if (InCell.I + i >= _board.Cells.GetLength(0) || InCell.I + i < 0) return;
            if (InCell.J + j >= _board.Cells.GetLength(1) || InCell.J + j < 0) return;

            for (int _i = InCell.I + i, _j = InCell.J + j;
                0 < _i && _i < _board.Cells.GetLength(0) && 0 < _j && _j < _board.Cells.GetLength(0);
                _i += i, _j += j)
            {
                AvalableCellsForMove.Add(_board.Cells[_i, _j]);
                if (!_board.Cells[_i, _j].IsFree())
                    break;
            }
        }
    }
}
