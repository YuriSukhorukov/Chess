using Assets.Scripts.Chess.Entities;
using Assets.Scripts.Chess.Interfaces;
using Chess.Interfaces;

namespace Assets.Scripts.Chess.Behaviours
{
    public class Bishop : FigureBase {
        public override void GetAvalableCellsForMove(IBoard board)
        {
            if (InCell == null) return;

            AvalableCellsForMove.Clear();

            int i = 1;
            
            while (InCell.I + i < board.Cells.GetLength(0) && InCell.J + i < board.Cells.GetLength(1))
            {
                AvalableCellsForMove.Add(board.Cells[InCell.I + i, InCell.J + i]);
                if(!board.Cells[InCell.I + i, InCell.J + i].IsFree())
                    break;
                i++;
            }
            
            i = 1;
            
            while (InCell.I - i >= 0 && InCell.J - i >= 0)
            {
                AvalableCellsForMove.Add(board.Cells[InCell.I - i, InCell.J - i]);
                if(!board.Cells[InCell.I - i, InCell.J - i].IsFree())
                    break;
                i++;
            }

            i = 1;
            
            while (InCell.I - i >= 0 && InCell.J + i < board.Cells.GetLength(1))
            {
                AvalableCellsForMove.Add(board.Cells[InCell.I - i, InCell.J + i]);
                if(!board.Cells[InCell.I - i, InCell.J + i].IsFree())
                    break;
                i++;
            }
            
            i = 1;
            
            while (InCell.I + i < board.Cells.GetLength(0) && InCell.J - i >= 0)
            {
                AvalableCellsForMove.Add(board.Cells[InCell.I + i, InCell.J - i]);
                if(!board.Cells[InCell.I + i, InCell.J - i].IsFree())
                    break;
                i++;
            }
        }
    }
}
