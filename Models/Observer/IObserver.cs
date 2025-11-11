namespace APS.Models.Observer
{
    public interface IObserver
    {
        void Update(string subjectName, string message);
    }
}