using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serwer
{
    class Message
    {
        public string from { get; }
        public string to{get;}
        public DateTime time { get; }

        public string message { get; }

       public Message(string from,string to,DateTime time,string message)
        {
            this.from = from;
            this.to = to;
            this.time = time;
            this.message = message;
        }

    }
}
