using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MailSender.lib.Service.MVVM;

namespace MailSender.WPF.Test.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "главное окно программы";

        public string Title
        {
            get => _Title;
            //set
            //{
            //    _Title = value;
            //    OnPropertyChanged();
            //}
            set => Set(ref _Title, value);
        }

        public ICommand ExitCommand => new LamdaCommand(p => Application.Current.Shutdown());
    }
}
