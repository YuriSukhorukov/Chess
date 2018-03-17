using Assets.Scripts.Chess.Entities;
using Assets.Scripts.Chess.Interfaces;
using Chess.Interfaces;

namespace Assets.Scripts.Chess.Behaviours
{
    public class Queen : FigureBase
    {
        public override void GetAvalableCellsForMove(IBoard board)
        {
            if (InCell == null) return;

            AvalableCellsForMove.Clear();

            int i = InCell.I + 1;
            while(i < board.Cells.GetLength(0))
            {
                AvalableCellsForMove.Add(board.Cells[i, InCell.J]);
                if(!board.Cells[i, InCell.J].IsFree())
                    break;
                i++;
            }

            i = InCell.I - 1;
            while (i >= 0)
            {
                AvalableCellsForMove.Add(board.Cells[i, InCell.J]);
                if(!board.Cells[i, InCell.J].IsFree())
                    break;
                i--;
            }

            int j = InCell.J + 1;
            while (j < board.Cells.GetLength(1))
            {
                AvalableCellsForMove.Add(board.Cells[InCell.I, j]);
                if(!board.Cells[InCell.I, j].IsFree())
                    break;
                j++;
            }

            j = InCell.J - 1;
            while (j >= 0)
            {
                AvalableCellsForMove.Add(board.Cells[InCell.I, j]);
                if(!board.Cells[InCell.I, j].IsFree())
                    break;
                j--;
            }
            
            int k = 1;
            while (InCell.I + k < board.Cells.GetLength(0) && InCell.J + k < board.Cells.GetLength(1))
            {
                AvalableCellsForMove.Add(board.Cells[InCell.I + k, InCell.J + k]);
                if(!board.Cells[InCell.I + k, InCell.J + k].IsFree())
                    break;
                k++;
            }
            
            k = 1;
            while (InCell.I - k >= 0 && InCell.J - k >= 0)
            {
                AvalableCellsForMove.Add(board.Cells[InCell.I - k, InCell.J - k]);
                if(!board.Cells[InCell.I - k, InCell.J - k].IsFree())
                    break;
                k++;
            }

            k = 1;
            while (InCell.I - k >= 0 && InCell.J + k < board.Cells.GetLength(1))
            {
                AvalableCellsForMove.Add(board.Cells[InCell.I - k, InCell.J + k]);
                if(!board.Cells[InCell.I - k, InCell.J + k].IsFree())
                    break;
                k++;
            }
            
            k = 1;
            while (InCell.I + k < board.Cells.GetLength(0) && InCell.J - k >= 0)
            {
                AvalableCellsForMove.Add(board.Cells[InCell.I + k, InCell.J - k]);
                if(!board.Cells[InCell.I + k, InCell.J - k].IsFree())
                    break;
                k++;
            }
        }
    }
}
