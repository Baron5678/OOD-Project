using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Logging
{
    public class State<T> : IState
    {
        private string _objectName;
        private string _propertynName;
        private T? _prevValue;
        private T? _updatedValue;
       
        public State()
        {
            _propertynName = "";
            _prevValue = default;
            _updatedValue = default;
            _objectName = string.Empty;
        }

        public State(string propertyName, T? prevValue, T? updatedValue)
        {
            _propertynName = propertyName;
            _prevValue = prevValue;
            _updatedValue = updatedValue;
            _objectName = string.Empty;
        }

        public string PropertyName
        {
            get => _propertynName;
            set => _propertynName = value;
        }

        public T? PrevValue
        {
            get => _prevValue;
            set => _prevValue = value;
        }

        public T? UpdatedValue
        {
            get => _updatedValue;
            set => _updatedValue = value;
        }

        public string ObjectName
        {
            get => _objectName;
            set => _objectName = value;
        }

        public override string ToString()
        {
            return $"UpdateTime: {DateTime.Now}\nObjectName: {_objectName}\nProperty: {_propertynName}\nPrevious Value: {_prevValue}\nUpdated Value: {_updatedValue}\n";
        }
    }
}
