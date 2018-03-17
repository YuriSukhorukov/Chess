using System;
using System.Text.RegularExpressions;
using Assets.Scripts.Chess.Interfaces;
using Assets.Scripts.Chess.Repositories;
using Assets.Scripts.Chess.Values;
using Chess.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Chess.Entities
{
	public class FigureConstructor : IConstructor<IFigure> {
		private IDataRepository<FigureComponentsSet> FiguresComponentsRepository { get; set; }
		
		public FigureConstructor(IDataRepository<FigureComponentsSet> figureComponents)
		{
			FiguresComponentsRepository = figureComponents;
		}

		public IFigure Construct(Vector3 position, GameObject parent, string name)
		{
//			Берем коллекцию компонентов для конкретной фигуры

			int firstRang = 0;
			if (name.Contains("white"))
				firstRang = 0;
			else if (name.Contains("black"))
				firstRang = 1;
			
			int figureIndex = Int32.Parse(Regex.Match(name, @"\d+").Value);
			
			FigureComponentsSet components = FiguresComponentsRepository.GetData(firstRang, figureIndex);
			
//			Добавить поведение для конкретной фигуры
			var figureGo = new GameObject(components.behaviour + "_" + name);
			
//			Добавляем компонетн по названию, который содержится в контейнере компонентов для конкретной фигуры.
			FigureBase figure =
				figureGo.AddComponent(
					Type.GetType(
						"Assets.Scripts.Chess.Behaviours." + components.behaviour
					)
				) as FigureBase;
			
			figureGo.transform.parent = parent.transform;
			
			var rectTransform = figureGo.AddComponent<RectTransform>();
			var figureSprite = figureGo.AddComponent<Image>().sprite = components.sprite;

			float aspect = figureSprite.rect.width / figureSprite.rect.height;
			rectTransform.localScale = new Vector3(1, 1, 1);
			rectTransform.sizeDelta = new Vector2(55f * aspect, 55f);

			figureGo.AddComponent<BoxCollider2D>().size = new Vector2(
				rectTransform.sizeDelta.x + rectTransform.sizeDelta.x * (1 - aspect),
				rectTransform.sizeDelta.y
			);

			var fColor = (FigureColor) firstRang;
			figure.SetupColor(fColor);

			return figure;
		}
	}
}
