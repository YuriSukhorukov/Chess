using Assets.Scripts.Chess.Entities;
using Assets.Scripts.Chess.Interfaces;
using Chess.Interfaces;

namespace Assets.Scripts.Chess.Behaviours
{
    public class Rook : FigureBase
    {
        public override void GetAvalableCellsForMove(IBoard board)
        {
            if (InCell == null) return;

            AvalableCellsForMove.Clear();

            for (int i = InCell.I + 1; i < board.Cells.GetLength(0); i++)
            {
                AvalableCellsForMove.Add(board.Cells[i, InCell.J]);
                if(!board.Cells[i, InCell.J].IsFree())
                    break;
            }
            
            for (int i = InCell.I - 1; i >= 0; i--)
            {
                AvalableCellsForMove.Add(board.Cells[i, InCell.J]);
                if(!board.Cells[i, InCell.J].IsFree())
                    break;
            }

            for (int j = InCell.J + 1; j < board.Cells.GetLength(1); j++)
            {
                AvalableCellsForMove.Add(board.Cells[InCell.I, j]);
                if(!board.Cells[InCell.I, j].IsFree())
                    break;
            }
            
            for (int j = InCell.J - 1; j >= 0; j--)
            {
                AvalableCellsForMove.Add(board.Cells[InCell.I, j]);
                if(!board.Cells[InCell.I, j].IsFree())
                    break;
            }
        }
    }
}
