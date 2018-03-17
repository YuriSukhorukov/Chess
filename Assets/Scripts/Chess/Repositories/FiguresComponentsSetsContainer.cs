using System;
using Assets.Scripts.Chess.Values;

namespace Assets.Scripts.Chess.Repositories
{
    [Serializable]
    public class FiguresComponentsSetsContainer
    {
        public FigureColor figuresColor;
        public FigureComponentsSet[] Components;
    }
}
