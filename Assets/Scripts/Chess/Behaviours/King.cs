using Assets.Scripts.Chess.Entities;
using Assets.Scripts.Chess.Interfaces;
using Chess.Interfaces;

namespace Assets.Scripts.Chess.Behaviours
{
    public class King : FigureBase
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
        
        private void MoveTo(int i = 0, int j = 0)
        {   
            if(i > 0)
                if(InCell.I + i >= _board.Cells.GetLength(0)) return;
            if(j > 0)
                if(InCell.J + j >= _board.Cells.GetLength(1)) return;
                
            if(i < 0)
                if(InCell.I + i < 0) return;
            if(j < 0)
                if(InCell.J + j < 0) return;

            AvalableCellsForMove.Add(_board.Cells[InCell.I + i, InCell.J + j]);
        }
    }
}
