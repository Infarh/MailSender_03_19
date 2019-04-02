using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace MailSender.WPF.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _Title = "Рассыльщик почты";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "Готов.";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        private double _Progress = 0.3;

        public double Progress
        {
            get => _Progress;
            set => Set(ref _Progress, value);
        }

    }
}
