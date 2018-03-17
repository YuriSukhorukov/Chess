using Assets.Scripts.Chess.Entities;
using Assets.Scripts.Chess.Interfaces;
using Chess.Interfaces;

namespace Assets.Scripts.Chess.Behaviours
{
    public class Knight : FigureBase
    {
        public override void GetAvalableCellsForMove(IBoard board)
        {
            if (InCell == null) return;

            AvalableCellsForMove.Clear();

            const int i = 1;
            const int j = 2;
            
            if (InCell.I + j < board.Cells.GetLength(0) && InCell.J + i < board.Cells.GetLength(1))
                AvalableCellsForMove.Add(board.Cells[InCell.I + j, InCell.J + i]);

            if (InCell.I - j >= 0 && InCell.J + i < board.Cells.GetLength(1))
                AvalableCellsForMove.Add(board.Cells[InCell.I - j, InCell.J + i]);

            if (InCell.I + j < board.Cells.GetLength(0) && InCell.J - i >= 0)
                AvalableCellsForMove.Add(board.Cells[InCell.I + j, InCell.J - i]);

            if (InCell.I - j >= 0 && InCell.J - i >= 0)
                AvalableCellsForMove.Add(board.Cells[InCell.I - j, InCell.J - i]);

            if (InCell.I + i < board.Cells.GetLength(0) && InCell.J + j < board.Cells.GetLength(1))
                AvalableCellsForMove.Add(board.Cells[InCell.I + i, InCell.J + j]);

            if (InCell.I - i >= 0 && InCell.J + j < board.Cells.GetLength(1))
                AvalableCellsForMove.Add(board.Cells[InCell.I - i, InCell.J + j]);

            if (InCell.I + i < board.Cells.GetLength(0) && InCell.J - j >= 0)
                AvalableCellsForMove.Add(board.Cells[InCell.I + i, InCell.J - j]);

            if (InCell.I - i >= 0 && InCell.J - j >= 0)
                AvalableCellsForMove.Add(board.Cells[InCell.I - i, InCell.J - j]);
        }
    }
}
