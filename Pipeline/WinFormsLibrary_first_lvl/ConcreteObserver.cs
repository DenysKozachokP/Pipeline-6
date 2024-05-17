using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ConcreteObserver : IObserver
    {
        private Result_base _subject;

        public ConcreteObserver(Result_base subject)
        {
            _subject = subject;
            _subject.Attach(this);
        }

        public void Update()
        {
            Console.WriteLine("ResultBase оновлено");
        }
    }
}
