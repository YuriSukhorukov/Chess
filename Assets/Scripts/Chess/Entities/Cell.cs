using System;
using Assets.Scripts.Chess.Interfaces;
using Chess.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Chess.Entities
{
    public class Cell : MonoBehaviour, ISelectable, ICell {
        
        public int I { get; private set; }
        public int J { get; private set; }
        
        public event EventHandler SelectEventHandler;

        private IFigure _figure;
        
        public void Select()
        {
            if(SelectEventHandler != null)
                SelectEventHandler.Invoke(this, new EventArgs());
        }

        public bool IsFree()
        {
            return _figure == null;
        }

        public void PutFigure(IFigure figure)
        {
            _figure = figure;
        }

        public void ReleaseCell()
        {
            _figure = null;
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public void SetIndexesInBoard(int i, int j)
        {
            I = i;
            J = j;
        }
    }
}
