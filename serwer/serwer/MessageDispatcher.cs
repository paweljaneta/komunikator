using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace serwer
{
    class MessageDispatcher
    {
        List<ClientConnection> clients = new List<ClientConnection>();
        Object clientsLock = new Object();

        Thread connectionAccepter;
        Thread messageDispatcher;

        TcpListener listener ;

        public MessageDispatcher()
        {
           // listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1024);
            listener = new TcpListener(1024);
            listener.Start();

            connectionAccepter = new Thread(connectionAcceptThread);
            messageDispatcher = new Thread(messageDispatchThread);
            connectionAccepter.Start();
            messageDispatcher.Start();

        }


        private void connectionAcceptThread()
        {
            while (true)
            {
                try
                {
                    TcpClient newClient = listener.AcceptTcpClient();

                    lock (clientsLock)
                    {
                        clients.Add(new ClientConnection(clients.Count,newClient));
                    }

                }
                catch (InvalidOperationException e)
                {
                    System.Console.WriteLine(e.Message);
                }
                catch(SocketException e)
                {
                    System.Console.WriteLine(e.Message);
                }
            } 
        }

        private void messageDispatchThread()
        {
            List<Message> messages = new List<Message>();
            while (true)
            {
                lock (clientsLock)
                {
                    for (int i = 0; i < clients.Count; i++)
                    {
                        if (clients[i].connected)
                        {
                            Message msg = clients[i].getRecievedMessage();
                            if (msg != null)
                            {
                                messages.Add(msg);
                            }
                            
                                
                            for (int j = 0; j < messages.Count; j++)
                            {
                                if (messages[j].to.Equals(clients[i].nick))
                                {
                                    clients[i].sendMessage(messages[j]);
                                    messages.RemoveAt(j);
                                }
                            }
                        }
                        else
                        {
                            clients.RemoveAt(i);
                        }

                    }
                }
                Thread.Sleep(100); 
            }
        }

    }
}
