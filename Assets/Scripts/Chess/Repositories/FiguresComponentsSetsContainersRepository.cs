using System;
using Assets.Scripts.Chess.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Chess.Repositories
{
	[Serializable]
	public class FiguresComponentsSetsContainersRepository : MonoBehaviour, IDataRepository<FigureComponentsSet>
	{
		[SerializeField]
		public FiguresComponentsSetsContainer[] ComponentsCollections;

		public FigureComponentsSet GetData(int firstRang, int secondRanc)
		{	
			return ComponentsCollections[firstRang].Components[secondRanc];
		}
	}
}
