using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Logging
{
    public class ErrorState : IState
    {
        private string _errorMessage;
        private string _objectName;

        public ErrorState()
        {
            _errorMessage = string.Empty;
            _objectName = string.Empty;
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => _errorMessage = value;
        }

        public string ObjectName
        {
            get => _objectName;
            set => _objectName = value;
        }

        public override string ToString()
        {
            return $"UpdateTime: {DateTime.Now}\nObjectName: {_objectName}\nError: {_errorMessage}\n";
        }
    }
}
