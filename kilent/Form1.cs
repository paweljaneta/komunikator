using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace kilent
{
    public partial class Form1 : Form
    {
        private Thread recieveThread { get; set; }
        private Object messageHistoryLock = new Object();

        private TcpClient connection;

        private BinaryReader inputStream;
        private BinaryWriter outputStream;

        private bool firstSend = true;

        public Form1()
        {

            InitializeComponent();

            connection = new TcpClient();

            try
            {

                connection.Connect("192.168.254.136", 1024);

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }


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

                recieveThread = new Thread(recieveMessages);
                recieveThread.Start();

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (firstSend)
            {
                if (nickText.Text.Length > 0)
                    outputStream.Write(nickText.Text);
                firstSend = false;
            }
            try
            {


                outputStream.Write("from");
                outputStream.Write(nickText.Text);
                outputStream.Write("to");
                outputStream.Write(toText.Text);
                outputStream.Write("message");
                outputStream.Write(messageText.Text);

                lock (messageHistoryLock)
                {
                    historyOfMessages.AppendText(nickText.Text+"   " + DateTime.Now.ToString() + Environment.NewLine + messageText.Text + Environment.NewLine);
                }
                messageText.Text = "";
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }


        private void recieveMessages()
        {
            while (true)
            {
                string from;
                string to;
                string message;
                string date;

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

                            date = inputStream.ReadString();

                            if (date.Equals("time"))
                            {
                                date = inputStream.ReadString();
                            }

                            lock (messageHistoryLock)
                            {
                                historyOfMessages.AppendText( "       " + from+"    "+ date + Environment.NewLine + "      " + message + Environment.NewLine);
                            }

                        }
                    }
                }


            }
        }

    }
}
