using OODProj.Data;
using OODProj.Data.Observers;
using OODProj.Data.Users;
namespace OODProj.AbstractFactories.UserFactories
{
    public class CrewFactory : IFactory
    {
        private List<string> _objectData = [];
        private ObserverInitializator _observerInitializator;

        public CrewFactory(ObserverInitializator observerInit)
        {
            _observerInitializator = observerInit;
        }

        public IFactory SetObjectData(string[] data)
        {
            _objectData = [.. data];
            return this;
        }

        public IPrimaryKeyed Create()
        {
            Crew crew = new(ulong.Parse(_objectData[0]),
                            _objectData[1],
                            ulong.Parse(_objectData[2]),
                            _objectData[3],
                            _objectData[4],
                            ushort.Parse(_objectData[5]),
                            _objectData[6]);
            StorageIDs.IDset.Add(ulong.Parse(_objectData[0]));
            StorageIDs.Objectsset.Add(ulong.Parse(_objectData[0]), crew);
            StorageIDs.UserObjects.Add(ulong.Parse(_objectData[0]), crew);
            _observerInitializator.AddSubject(crew);
            return crew;
        }

        public void ResetObjectData() => _objectData = [];

    }
}
