using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatAppServerSide.Helpers
{
    public class MessageBoxHelpers
    {
        public static async void ShowInformationAsync(string message)
        {
            await Task.Run(() =>
            {
                MessageBox.Show(message, String.Empty, MessageBoxButton.OK, MessageBoxImage.Information);
            });
        }
    }
}
