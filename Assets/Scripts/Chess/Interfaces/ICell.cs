using System;
using Chess.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Chess.Interfaces
{
    public interface ICell
    {
        event EventHandler SelectEventHandler;
        
        void PutFigure(IFigure figure);
        
        int I { get; }
        int J { get; }

        void SetIndexesInBoard(int i, int j);
        
        bool IsFree();
        void ReleaseCell();

        Vector3 GetPosition();
    }
}
