using System.Collections.Generic;
using Chess.Interfaces;

namespace Assets.Scripts.Chess.Interfaces
{
    public interface IBoard {        
        ICell[,] Cells { get; } 
        List<IFigure> FiguresWhite { get; }
        List<IFigure> FiguresBlack { get; }

        void AddWhiteFigure(IFigure figure);
        void AddBlackFigure(IFigure figure);

        void Create(int column, int rows);
    }
}
