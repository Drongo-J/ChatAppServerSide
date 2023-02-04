using ChatAppServerSide.Helpers;
using ChatAppServerSide.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatAppServerSide.Services.NetworkServices
{
    public class NetworkService
    {
        private static TcpListener listener = null;
        private static BinaryReader reader = null;
        private static BinaryWriter writer = null;

        public static TcpClient SelectedClient = null;

        public static string ServerMessage { get; set; } = String.Empty;

        public static void ConnectToServer()
        {
            var ipAdress = IPAddress.Parse(NetworkHelpers.GetLocalIpAddress());
            var port = NetworkConstants.PORT;

            var ep = new IPEndPoint(ipAdress, port);

            listener = new TcpListener(ep);
            listener.Start();

            //MessageBoxHelpers.ShowInformationAsync($"Listening on {listener.LocalEndpoint}");

            while (true)
            {
                var client = listener.AcceptTcpClient();

                if (client != null)
                {
                    var hostname = App.AddClientToView(client);

                    //MessageBoxHelpers.ShowInformationAsync($"{hostname} connected . . .");

                    try
                    {
                        Receive(client);
                        Send();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        static void Receive(TcpClient client)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    var stream = client.GetStream();
                    reader = new BinaryReader(stream);
                    var message = reader.ReadString();
                    if (message == "exit")
                    {
                        App.RemoteClient(client);
                        break;
                    }

                    if (message != string.Empty)
                    {
                        App.IntegrateMessageToView(client, message);
                        App.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            App.ScrollViewer.ScrollToBottom();
                        }));
                    }
                }
            });
        }

        static void Send()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if (SelectedClient != null)
                    {
                        while (true)
                        {
                            var stream = SelectedClient.GetStream();
                            writer = new BinaryWriter(stream);
                            // send message to client 
                            if (ServerMessage != String.Empty)
                            {
                                writer.Write(ServerMessage);
                                ServerMessage = String.Empty;
                            }
                        }
                    }
                }
            });
        }
    }
}
