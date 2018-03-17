using System;
using Assets.Scripts.Chess.Interfaces;
using Assets.Scripts.Chess.Values;
using UnityEngine;

namespace Chess.Interfaces
{
    public interface IFigure
    {
        event EventHandler FigureTakenEventHandler;
        event EventHandler MoveCompleteEventHandler;

        void MoveToCellInBoard(ICell cell, IBoard board);
        void PutInCell(ICell cell);
        void AttackFigure(IFigure figure);
        void SetupColor(FigureColor figureColor);
        void Kill();
        bool IsColor(FigureColor figureColor);
        
        ICell InCell { get; }
        FigureColor FigureColor { get; }
    }
}
