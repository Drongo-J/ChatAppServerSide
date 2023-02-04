using ChatAppServerSide.Commands;
using ChatAppServerSide.Services.NetworkServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServerSide.ViewModels
{
    public class SendMessageWindowViewModel : BaseViewModel
    {
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand SendMessageCommand { get; set; }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }

        public SendMessageWindowViewModel(Action action, TcpClient client)
        {
            CloseCommand = new RelayCommand((a) =>
            {
                action();
            });

            SendMessageCommand = new RelayCommand((a) =>
            {
                NetworkService.SelectedClient = client;
                NetworkService.ServerMessage = Message;
                Message = String.Empty;
            });
        }

    }
}
