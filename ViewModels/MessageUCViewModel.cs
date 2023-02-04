using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServerSide.ViewModels
{
    public class MessageUCViewModel : BaseViewModel
    {
		private string message;

		public string Message
        {
			get { return message; }
			set { message = value; OnPropertyChanged(); }
		}
	}
}
