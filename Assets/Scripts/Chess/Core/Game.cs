using System;
using Assets.Scripts.Chess.Entities;
using Assets.Scripts.Chess.Interfaces;
using Assets.Scripts.Chess.Values;
using Chess.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Chess.Core
{   
    public class Game : MonoBehaviour
    {
        private IBoardBuilder _boardBuilder;
        private IBoard _board;
        private ISelector _selector;
        
        private IFigure _selectedFigure;

        public FigureBase SelectedFigure;
        public FigureColor ActiveFiguresColor;

        public void Start()
        {

//           Создание строителя шахматной доски.
//           Создание доски.
//           Создание объектв для выбора фигур и ячеек.

            _boardBuilder = new BoardBuilder();
            _board = _boardBuilder.Build();
            _selector = new Selector();

//          Подписка на события фигур и клеток игрового поля
            SubscribeToCells();
            SubscribeToFigures();

//          Первыми ходя белые
            ActiveFiguresColor = FigureColor.WHITE;
        }

        public void Update()
        {
//          Выход из метода, если нет ввода
            if (!Input.GetMouseButtonDown(0)) return;
            
            Vector3 pos = new  Vector2(Input.mousePosition.x, Input.mousePosition.y);
            pos = Camera.main.ScreenToWorldPoint(pos);
            
//          Выбор объекта, реализующего интерфейс ISelectable
            _selector.PickUp(pos.x, pos.y);
        }

//      Подписка на события ячеейк игрового поля
        private void SubscribeToCells()
        {
            for (var i = 0; i < _board.Cells.GetLength(0); i++)
            {
                for (var j = 0; j < _board.Cells.GetLength(1); j++)
                {
                    int _i = i;
                    int _j = j;

                    _board.Cells[i, j].SelectEventHandler += (s, e) => { CellSelectEventHandler(_i, _j); };
                }
            }
        }

//      Подписка на события игровых фигур
        private void SubscribeToFigures()
        {
            foreach (var f in _board.FiguresWhite)
            {
                var f1 = f;
                
                f.MoveCompleteEventHandler += (s, e) => { FigureMoveCompleteEventHandler(f1); };
                f.FigureSelectEventHandler += (s, e) => { FigureSelectEventHandler(f1); };
            }
            foreach (var f in _board.FiguresBlack)
            {
                var f1 = f;
                
                f.MoveCompleteEventHandler += (s, e) => { FigureMoveCompleteEventHandler(f1); };
                f.FigureSelectEventHandler += (s, e) => { FigureSelectEventHandler(f1); };
            }
        }

//      Обработка события выбора ячейки
        private void CellSelectEventHandler(int i, int j)
        {
            if (SelectedFigure == null) return;
                        
            if (ActiveFiguresColor == SelectedFigure.FigureColor)
                SelectedFigure.MoveToCellInBoard(_board.Cells[i, j], _board);
        }

//      Обработка события завершения хода
        private void FigureMoveCompleteEventHandler(IFigure figure)
        {
            ActiveFiguresColor = ActiveFiguresColor == FigureColor.BLACK ? FigureColor.WHITE : FigureColor.BLACK;
            SelectedFigure = null;
        }

//      Обработка события выбора фигуры
        private void FigureSelectEventHandler(IFigure figure)
        {
            if (ActiveFiguresColor == figure.FigureColor)
            {
                _selectedFigure = figure;
                SelectedFigure = (FigureBase) _selectedFigure;
                SelectedFigure.GetAvalableCellsForMove(_board);
            }
            else if (ActiveFiguresColor != figure.FigureColor &&
                     SelectedFigure != null)
            {
                SelectedFigure.AttackFigure(figure);
            }
        }
    }
}
