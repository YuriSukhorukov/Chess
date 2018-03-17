using System;
using System.Collections.Generic;
using Assets.Scripts.Chess.Interfaces;
using Chess.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Chess.Entities
{
	public class Board : MonoBehaviour, IBoard
	{
		public ICell[,] Cells { get; set; }
		
		public List<IFigure> FiguresWhite { get; private set; }
		public List<IFigure> FiguresBlack { get; private set; }

		public void Create(int column, int rows)
		{
			Cells = new ICell[8, 8];
		}
		
		public void AddWhiteFigure(IFigure figure)
		{
			if(FiguresWhite == null)
				FiguresWhite = new List<IFigure>();
			FiguresWhite.Add(figure);
		}
		public void AddBlackFigure(IFigure figure)
		{
			if(FiguresBlack == null)
				FiguresBlack = new List<IFigure>();
			FiguresBlack.Add(figure);
		}

		public void RemoveWhiteFigure(IFigure figure)
		{
			if (FiguresWhite.Contains(figure))
				FiguresWhite.Remove(figure);
		}
		public void RemoveBlackFigure(IFigure figure)
		{
			if (FiguresBlack.Contains(figure))
				FiguresBlack.Remove(figure);
		}
	}
}
