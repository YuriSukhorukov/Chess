namespace Assets.Scripts.Chess.Interfaces
{
    public interface IDataRepository<out T> where T : class
    {
        T GetData(int firstRang, int secondRanc);
    }
}
