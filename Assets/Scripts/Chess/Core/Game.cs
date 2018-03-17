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
            /*
             Создание строителя шахматной доски.
             Создание доски.
             Создание объектв для выбора фигур и ячеек.
             */
            _boardBuilder = new BoardBuilder();
            _board = _boardBuilder.Build();
            _selector = new Selector();

            //Подписка на события фигур и клеток игрового поля
            SubscribeToCells();
            SubscribeToFigures();

            //Первыми ходя белые
            ActiveFiguresColor = FigureColor.WHITE;
        }

        public void Update()
        {
            //Выход из метода, если нет ввода
            if (!Input.GetMouseButtonDown(0)) return;
            
            Vector3 pos = new  Vector2(Input.mousePosition.x, Input.mousePosition.y);
            pos = Camera.main.ScreenToWorldPoint(pos);
            
            //Выбор объекта, реализующего интерфейс ISelectable
            _selector.PickUp(pos.x, pos.y);
        }

        /// <summary>
        /// Подписка на события ячеейк игрового поля
        /// </summary>
        private void SubscribeToCells()
        {
            for (var i = 0; i < _board.Cells.GetLength(0); i++)
            {
                for (var j = 0; j < _board.Cells.GetLength(1); j++)
                {
                    int _i = i;
                    int _j = j;
                    
                    _board.Cells[i, j].SelectEventHandler += (s, e) =>
                    {
                        if (SelectedFigure == null) return;
                        
                        if (ActiveFiguresColor == SelectedFigure.FigureColor)
                            SelectedFigure.MoveToCellInBoard(_board.Cells[_i, _j], _board);
                    };
                }
            }
        }

        /// <summary>
        /// Подписка на события игровых фигур
        /// </summary>
        private void SubscribeToFigures()
        {
            foreach (var t in _board.FiguresWhite)
            {
                var t1 = t;
                t.MoveCompleteEventHandler += (s, e) =>
                {
                    ActiveFiguresColor = FigureColor.BLACK;
                    SelectedFigure = null;
                };
                
                t.FigureTakenEventHandler += (s, e) =>
                {
                    if (ActiveFiguresColor == FigureColor.WHITE && t1.IsColor(FigureColor.WHITE))
                    {
                        _selectedFigure = t1;
                        SelectedFigure = (FigureBase) _selectedFigure;
                        SelectedFigure.GetAvalableCellsForMove(_board);
                    }
                    else if (ActiveFiguresColor == FigureColor.BLACK && t1.IsColor(FigureColor.WHITE) &&
                             SelectedFigure != null)
                    {
                        SelectedFigure.AttackFigure(t1);
                    }
                };
            }
            foreach (var t in _board.FiguresBlack)
            {
                var t1 = t;

                t.MoveCompleteEventHandler += (s, e) =>
                {
                    ActiveFiguresColor = FigureColor.WHITE;
                    SelectedFigure = null;
                };
                
                t.FigureTakenEventHandler += (s, e) =>
                {
                    if (ActiveFiguresColor == FigureColor.BLACK && t1.IsColor(FigureColor.BLACK))
                    {
                        _selectedFigure = t1;
                        SelectedFigure = (FigureBase) _selectedFigure;
                        SelectedFigure.GetAvalableCellsForMove(_board);
                    }
                    else if (ActiveFiguresColor == FigureColor.WHITE && t1.IsColor(FigureColor.BLACK) && SelectedFigure != null)
                    {
                        SelectedFigure.AttackFigure(t1);
                    }
                };
            }
        }
    }
}
