using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace serwer
{
    class ClientConnection
    {
       public string nick { get; }
        public int id { get; }

        private TcpClient connection { get; }

        private BinaryReader inputStream;
        private BinaryWriter outputStream;

        private Thread recieveThread;

        public Message recievedMessage { get; set; }
        private Object recievedMessageLock = new Object();

        public bool connected { get; set; }

        public ClientConnection(int id, TcpClient connection)
        {
            recievedMessage = null;

           // this.nick = nick;
            this.id = id;
            this.connection = connection;

            try
            {
                inputStream = new BinaryReader(connection.GetStream());
                outputStream = new BinaryWriter(connection.GetStream());
            }
            catch (ArgumentException e)
            {
                System.Console.WriteLine(e.Message);
            }


            try
            {
                nick = inputStream.ReadString();

                recieveThread = new Thread(recieveMessage);
                recieveThread.Start();
                connected = true;
            }
            catch (EndOfStreamException e)
            {
                System.Console.WriteLine(e.Message);
                connected = false;
            }
            catch (ObjectDisposedException e)
            {
                System.Console.WriteLine(e.Message);
                connected = false;
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
                connected = false;
            }


        }

        private void recieveMessage()
        {
            

            try
            {
                while (true)
                {
                    string from;
                    string to;
                    string message;


                    from = inputStream.ReadString();

                    if (from.Equals("from"))
                    {
                        from = inputStream.ReadString();

                        to = inputStream.ReadString();
                        if (to.Equals("to"))
                        {
                            to = inputStream.ReadString();

                            message = inputStream.ReadString();

                            if (message.Equals("message"))
                            {
                                message = inputStream.ReadString();

                                DateTime time = DateTime.Now;

                               while(recievedMessage!= null)
                                {
                                    Thread.Sleep(500);
                                }

                                lock (recievedMessageLock)
                                {
                                    recievedMessage = new Message(from, to, time, message);
                                }
                            }
                        }
                    }
                }
            }
            catch (EndOfStreamException e)
            {
                System.Console.WriteLine(e.Message);
                connected = false;
            }
            catch (ObjectDisposedException e)
            {
                System.Console.WriteLine(e.Message);
                connected = false;
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
                connected = false;
            }
        }

        public void sendMessage(Message message)
        {
            try
            {
                outputStream.Write("from");
                outputStream.Write(message.from);
                outputStream.Write("to");
                outputStream.Write(message.to);
                outputStream.Write("message");
                outputStream.Write(message.message);
                outputStream.Write("time");
                outputStream.Write(message.time.ToString());
            }
            catch (EndOfStreamException e)
            {
                System.Console.WriteLine(e.Message);
                connected = false;
            }
            catch (ObjectDisposedException e)
            {
                System.Console.WriteLine(e.Message);
                connected = false;
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
                connected = false;
            }
        }

        public Message getRecievedMessage()
        {

            Message result = recievedMessage;
            recievedMessage = null;

            return result;
        }

    }
}
