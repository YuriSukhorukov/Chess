using System;
using System.Collections.Generic;
using Assets.Scripts.Chess.Interfaces;
using Assets.Scripts.Chess.Values;
using Chess.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Chess.Entities
{
	public abstract class FigureBase : MonoBehaviour, ISelectable, IFigure
	{	
		public event EventHandler FigureSelectEventHandler;
		public event EventHandler MoveCompleteEventHandler;

		public ICell InCell { get; private set; }
		public FigureColor FigureColor { get; private set; }

		public List<ICell> AvalableCellsForMove = new List<ICell>();

		public void SetupColor(FigureColor fColor)
		{
			FigureColor = fColor;
		}

		public bool IsColor(FigureColor fColor)
		{
			return fColor == FigureColor;
		}

		public void Select()
		{
			if (FigureSelectEventHandler != null)
				FigureSelectEventHandler.Invoke(this, new EventArgs());
		}

		public void PutInCell(ICell cell)
		{
			if (!cell.IsFree()) return;
			
			cell.PutFigure(this);
				
			if(InCell != null)
				InCell.ReleaseCell();
				
			InCell = cell;

			transform.position = InCell.GetPosition();
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -1);
				
			if(MoveCompleteEventHandler != null)
				MoveCompleteEventHandler.Invoke(this, new EventArgs());
		}

		public void MoveToCellInBoard(ICell cell, IBoard board)
		{
			if (!AvalableCellsForMove.Contains(cell) || !cell.IsFree()) return;
			
			PutInCell(cell);
		}
		
		public void AttackFigure(IFigure figure)
		{
			if (!AvalableCellsForMove.Contains(figure.InCell)) return;

			var cellToMove = figure.InCell;
			figure.Kill();
			PutInCell(cellToMove);
		}

		public void Kill()
		{		
			transform.position = InCell.GetPosition();
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -1);
			gameObject.SetActive(false);
			
			if(InCell != null)
				InCell.ReleaseCell();
		}

		public abstract void GetAvalableCellsForMove(IBoard board);
	}
}
