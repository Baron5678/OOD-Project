using OODProj.Data;
using OODProj.Data.Planes;
using OODProj.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace OODProj.StrategiesGettingData.DataSerializers
{
    public class JSONSerializer: IVisitor
    {
        private string _path;

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private JsonSerializerOptions _options;


        public JSONSerializer(string defaultPath)
        {
            _path = defaultPath;
            _options = new JsonSerializerOptions();

            _options.WriteIndented = true;

        }
       
        public void Visit(CargoPlaneRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.CargoPlanes, _options);

            File.WriteAllText(_path, jsonString);
        }

        public void Visit(PassengerPlaneRepository repo)
        {
            string jsonString = JsonSerializer.Serialize(repo.PassengerPlane, _options);

            File.WriteAllText(_path, jsonString);
        }
    }
}
