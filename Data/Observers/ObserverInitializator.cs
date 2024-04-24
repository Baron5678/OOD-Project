using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProj.Data.Observers
{
    public sealed class ObserverInitializator
    {
        private List<ISubject> _subjects;
        private List<IObserver> _observers;

        public ObserverInitializator()
        {
           _subjects = [];
           _observers = [];
        }

        public void AddSubject(ISubject subject)
        {
            _subjects.Add(subject);
        }

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }
         
        public void SetUpRelation()
        {
            foreach (var observer in _observers)
            {
                foreach (var subject in _subjects)
                {
                  subject.Attach(observer);  
                }
            }
        }
    }
}

