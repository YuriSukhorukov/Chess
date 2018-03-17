using Assets.Scripts.Chess.Interfaces;
using Chess.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Chess.Entities
{
	public class CellConstructor : IConstructor<ICell>
	{
		public ICell Construct(Vector3 position, GameObject parent, string name)
		{
			var cellGo = new GameObject(name);
			
			cellGo.transform.parent = parent.transform;

			var rectTransform = cellGo.AddComponent<RectTransform>();
			rectTransform.localPosition = new Vector3(position.x * 62.5f - 62.5f * 3.5f, position.y * 62.5f - 62.5f * 3.5f, 0);
			rectTransform.localScale = new Vector3(1, 1);
			rectTransform.sizeDelta = new Vector2(62.5f, 62.5f);

			cellGo.AddComponent<BoxCollider2D>().size = rectTransform.sizeDelta;

			ICell cell = cellGo.AddComponent<Cell>();
			cell.SetIndexesInBoard((int)position.x, (int)position.y);
			
			return cell;
		}
	}
}
