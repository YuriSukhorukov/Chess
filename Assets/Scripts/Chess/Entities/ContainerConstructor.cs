using Assets.Scripts.Chess.Interfaces;
using Chess.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Chess.Entities
{
	public class ContainerConstructor : IConstructor<GameObject>
	{
		public GameObject Construct(Vector3 position, GameObject parent, string name)
		{
			var container = new GameObject(name);
			container.transform.parent = parent.transform;
			container.transform.localPosition = position;
			
			var cellsRt = container.AddComponent<RectTransform>();
			cellsRt.sizeDelta = new Vector2(500f, 500f);
			cellsRt.localScale = new Vector3(1, 1, 1);

			return container;
		}
	}
}
