using System.Collections;

namespace Galaxy.GoogleReader.Client
{
    public class Subject : ISubject
    {
        ArrayList observers = new ArrayList();
        #region Implementation of ISubject

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify(object realSubject)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(realSubject);
            }
        }

        #endregion
    }
}