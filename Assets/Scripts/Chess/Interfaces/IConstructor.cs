using UnityEngine;

namespace Assets.Scripts.Chess.Interfaces
{
    public interface IConstructor<out T>
    {
        T Construct(Vector3 position, GameObject parent, string name);
    }
}
