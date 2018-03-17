using Assets.Scripts.Chess.Interfaces;
using Chess.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Chess.Entities
{
	public class Selector : ISelector {
		public void PickUp(params float[] coords)
		{
			var hit = Physics2D.Raycast(new Vector2(coords[0], coords[1]), Vector2.zero, 0);
			if(hit)
				hit.transform.gameObject.GetComponent<ISelectable>().Select();
		}
	}
}
