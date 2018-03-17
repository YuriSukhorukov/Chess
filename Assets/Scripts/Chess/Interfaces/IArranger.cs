namespace Assets.Scripts.Chess.Interfaces
{
    public interface IArranger<in T, in T1>
    {
        void ArrangeObjectsToObjects(T objectForArrange, T1 objectToArrange);
    }
}
