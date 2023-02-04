using ChatAppServerSide.Helpers;
using ChatAppServerSide.Services.NetworkServices;
using ChatAppServerSide.ViewModels;
using ChatAppServerSide.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatAppServerSide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var VM = new MainWindowViewModel();
            App.ScrollViewer = ScrollViewer;
            this.DataContext = VM;
            App.MainWindowViewModel = VM;
        }
    }
}
