using System.Collections.Generic;
using Assets.Scripts.Chess.Interfaces;
using Assets.Scripts.Chess.Repositories;
using Chess.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Chess.Entities
{
	public class BoardBuilder : IBoardBuilder
	{
		public IBoard Build()
		{
			//Игициализация объекта шахматной доски на сцене
			var canvasGameObject = GameObject.Find("Canvas");
			var board = GameObject.Find("Chees Board").GetComponent<IBoard>();
			
			//Создание конствукторов ячеек и фигур
			var figuresData = GameObject.Find("FiguresData").GetComponent<FiguresComponentsSetsContainersRepository>();
			IConstructor<IFigure> figureConstructor = new FigureConstructor(figuresData);
			IConstructor<ICell> cellConstructor = new CellConstructor();
			
			//Создание расстановщиков белых и черных фигур
			IArranger<IFigure[], ICell[,]> arrangerWhiteFigures = new FiguresWhiteToCellsArranger<IFigure, ICell>();
			IArranger<IFigure[], ICell[,]> arrangerBlackFigures = new FiguresBlackToCellsArranger<IFigure, ICell>();
			
			//Создание конструктора контейнеров для ячеек и фигур
			var containerConstructor = new ContainerConstructor();

			//Создание контейнеров на сцене для ячеек и фигур
			var cellsContainer = containerConstructor.Construct(Vector3.zero, canvasGameObject, "Cells");
			var figuresContainer = containerConstructor.Construct(Vector3.back, canvasGameObject, "Figures");

			//Создание игрового поля, размером 8х8 клеток
			board.Create(8, 8);
			
			//Конструирование нужного количество ячеек
			for (var i = 0; i < board.Cells.GetLength(0); i++)
			{
				for (var j = 0; j < board.Cells.GetLength(1); j++)
				{
					board.Cells[i, j] = cellConstructor.Construct(
						new Vector2(i, j),
						cellsContainer,
						i + "-" + j
					);
				}
			}

			//Создание белых фигур и добавление их в коллекцию
			IEnumerable<IFigure> figuresWhite = CreateFigures(16, figureConstructor, figuresContainer, "figure_white");
			foreach (var figure in figuresWhite)
			{
				board.AddWhiteFigure(figure);
			}
			
			//Создание черных фигур и добавление их в коллекцию
			IEnumerable<IFigure> figuresBlack = CreateFigures(16, figureConstructor, figuresContainer, "figure_black");
			foreach (var figure in figuresBlack)
			{
				board.AddBlackFigure(figure);
			}
			
			//Расстановка белых и черных фигур в соответствующие точки
			arrangerWhiteFigures.ArrangeObjectsToObjects(board.FiguresWhite.ToArray(), board.Cells);
			arrangerBlackFigures.ArrangeObjectsToObjects(board.FiguresBlack.ToArray(), board.Cells);

			return board;
		}

		/// <summary>
		/// Создание списка фигур
		/// </summary>
		/// <param name="count">количество фигур</param>
		/// <param name="constructor">конструкток фигур</param>
		/// <param name="container">контейнер фигур на сцене</param>
		/// <param name="name">часть имени</param>
		/// <returns></returns>
		private static IEnumerable<IFigure> CreateFigures(int count, IConstructor<IFigure> constructor, GameObject container, string name)
		{
			var figures = new List<IFigure>();
			
			for (var i = 0; i < count; i++)
			{
				figures.Add(
					constructor.Construct(
						new Vector2(0, 0),
						container,
						name + "-" + i
					)
				);
			}

			return figures;
		}
	}
}
