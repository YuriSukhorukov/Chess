using Assets.Scripts.Chess.Interfaces;
using Chess.Interfaces;

namespace Assets.Scripts.Chess.Entities
{
    public class FiguresWhiteToCellsArranger<TFigure,TCell> : IArranger<TFigure[], TCell[,]> 
        where TFigure: IFigure 
        where TCell: ICell
    {
        public void ArrangeObjectsToObjects(TFigure[] figures, TCell[,] cells)
        {
            int figureIndex = 0;
            for (int j = 0; j < cells.GetLength(0); j++)
            {
                figures[figureIndex].PutInCell(cells[j, 0]);
                if (figureIndex + 1 < figures.Length)
                    figureIndex += 1;
                else
                    break;
            }
            
            for (int j = 0; j < cells.GetLength(0); j++)
            {
                figures[figureIndex].PutInCell(cells[j, 1]);
                if (figureIndex + 1 < figures.Length)
                    figureIndex += 1;
                else
                    break;
            }
        }
    }
}