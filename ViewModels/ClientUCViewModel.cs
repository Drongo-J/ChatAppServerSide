using ChatAppServerSide.Commands;
using ChatAppServerSide.Services.NetworkServices;
using ChatAppServerSide.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServerSide.ViewModels
{
    public class ClientUCViewModel : BaseViewModel
    {
        public RelayCommand MessageToClientCommand { get; set; }

        private TcpClient client;

        public TcpClient Client
        {
            get { return client; }
            set { client = value; OnPropertyChanged(); }
        }

        private string clientHostName;

        public string ClientHostName
        {
            get { return clientHostName; }
            set { clientHostName = value; OnPropertyChanged(); }
        }

        public ClientUCViewModel(TcpClient _client)
        {
            Client = _client;

            MessageToClientCommand = new RelayCommand((m) =>
            {
                var sendMessageWindow = new SendMessageWindow();
                sendMessageWindow.Owner = App.Current.MainWindow;
                var action = new Action(() =>
                {
                    sendMessageWindow.Close();
                    NetworkService.SelectedClient = null;
                });
                var sendMessageWindowVM = new SendMessageWindowViewModel(action, Client);
                sendMessageWindow.DataContext = sendMessageWindowVM;
                sendMessageWindow.Show();
            });
        }
    }
}
