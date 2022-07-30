using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logger
{
    public class ConsoleLog : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("ConsoleLogger - " + message);
        }
    }
}
