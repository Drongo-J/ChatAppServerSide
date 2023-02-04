using ChatAppServerSide.Services.NetworkServices;
using ChatAppServerSide.ViewModels;
using ChatAppServerSide.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChatAppServerSide
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindowViewModel MainWindowViewModel { get; internal set; }
        public static ScrollViewer ScrollViewer { get; internal set; }

        // returns hostname
        public static string AddClientToView(TcpClient client)
        {
            IPEndPoint endPoint = (IPEndPoint)client.Client.RemoteEndPoint;
            IPAddress ipAddress = endPoint.Address;
            var hostname = NetworkHelpers.GetHostName(ipAddress.ToString());
            App.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                var clientUC = new ClientUC();
                var clientUCVM = new ClientUCViewModel(client);
                string name = hostname + " : " + client.Client.RemoteEndPoint;
                clientUCVM.ClientHostName = name;
                clientUC.DataContext = clientUCVM;
                if (MainWindowViewModel.LastClient != string.Empty)
                    MainWindowViewModel.LastClient = name;
                MainWindowViewModel.Clients.Add(clientUC);
            }));
            return hostname;
        }

        public static void IntegrateMessageToView(TcpClient client, string message)
        {
            App.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                IPEndPoint endPoint = (IPEndPoint)client.Client.RemoteEndPoint;
                IPAddress ipAddress = endPoint.Address;
                var hostname = NetworkHelpers.GetHostName(ipAddress.ToString());
                string name = hostname + " : " + client.Client.RemoteEndPoint;

                var messageUC = new MessageUC();
                var messageUCVM = new MessageUCViewModel();
                messageUC.DataContext = messageUCVM;
                messageUCVM.Message = message;
                if (MainWindowViewModel.LastClient != name)
                {
                    var item = new Item();
                    item.name.Text = name;
                    MainWindowViewModel.Messages.Add(item);
                    MainWindowViewModel.LastClient = name;
                }
                MainWindowViewModel.Messages.Add(messageUC);
            }));
        }

        internal static void RemoteClient(TcpClient client)
        {
            App.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                var clientUC = MainWindowViewModel.Clients.Where(c => (c.DataContext as ClientUCViewModel).Client == client).FirstOrDefault();

                if (clientUC != null)
                {
                    MainWindowViewModel.Clients.Remove(clientUC);
                }
            }));
        }
    }
}
