using Assets.Scripts.Chess.Entities;
using Assets.Scripts.Chess.Interfaces;
using Chess.Interfaces;

namespace Assets.Scripts.Chess.Behaviours
{
    public class King : FigureBase
    {
        public override void GetAvalableCellsForMove(IBoard board)
        {
            if (InCell == null) return;

            AvalableCellsForMove.Clear();

            const int i = 1;
            
            if(InCell.I + i < board.Cells.GetLength(0))
                AvalableCellsForMove.Add(board.Cells[InCell.I + i, InCell.J]);
            if(InCell.I - i >= 0)
                AvalableCellsForMove.Add(board.Cells[InCell.I - i, InCell.J]);
            if(InCell.J + i <  board.Cells.GetLength(1))
                AvalableCellsForMove.Add(board.Cells[InCell.I, InCell.J + i]);
            if(InCell.J - i >= 0)
                AvalableCellsForMove.Add(board.Cells[InCell.I, InCell.J - i]);
            
            if(InCell.I + i < board.Cells.GetLength(0) && InCell.J + i < board.Cells.GetLength(1))
                AvalableCellsForMove.Add(board.Cells[InCell.I + i, InCell.J + i]);
            if(InCell.I - i >= 0 && InCell.J + i < board.Cells.GetLength(1))
                AvalableCellsForMove.Add(board.Cells[InCell.I - i, InCell.J + i]);
            if(InCell.I - i >= 0 && InCell.J - i >= 0)
                AvalableCellsForMove.Add(board.Cells[InCell.I - i, InCell.J - i]);
            if(InCell.I + i < board.Cells.GetLength(0) && InCell.J - i >= 0)
                AvalableCellsForMove.Add(board.Cells[InCell.I + i, InCell.J - i]);
        }
    }
}
