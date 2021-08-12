using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class Log
    {
        private string _Log;
        
        public string MessageLog
        {
            get { return _Log; }
            set { _Log = value; }
        }

        public void ConsoleWriteLog(string s)
        {
            System.Diagnostics.Debug.WriteLine("GAME_LOG_OUTPUT " + DateTime.Now.ToString() + " - " + s);            
        }

    }
    
}
