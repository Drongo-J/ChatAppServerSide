using ChatAppServerSide.Services.NetworkServices;
using ChatAppServerSide.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChatAppServerSide.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ObservableCollection<ClientUC> clients = new ObservableCollection<ClientUC>();

        public ObservableCollection<ClientUC> Clients
        {
            get { return clients; }
            set { clients = value; OnPropertyChanged(); }
        }

        public string LastClient { get; set; } = String.Empty;

        private ObservableCollection<UIElement> messages = new ObservableCollection<UIElement>();

        public ObservableCollection<UIElement> Messages
        {
            get { return messages; }
            set { messages = value; OnPropertyChanged(); }
        }

        public MainWindowViewModel()
        {
            Task.Run(() =>
            {
                NetworkService.ConnectToServer();
            });
        }
    }
}
