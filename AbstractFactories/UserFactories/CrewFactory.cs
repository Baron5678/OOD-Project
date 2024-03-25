using OODProj.Data;
using OODProj.Data.Users;
namespace OODProj.AbstractFactories.UserFactories
{
    public class CrewFactory : IFactory
    {
        private List<string> _objectData = [];
        
        public IFactory SetObjectData(string[] data)
        {
            _objectData = [.. data];
            return this;
        }

        public IPrimaryKeyed Create()
        {
            return new Crew(ulong.Parse(_objectData[0]), 
                            _objectData[1], 
                            ulong.Parse(_objectData[2]),
                            _objectData[3],
                            _objectData[4],
                            ushort.Parse(_objectData[5]),
                            _objectData[6]);
        }

        public void ResetObjectData() => _objectData = [];

    }
}
