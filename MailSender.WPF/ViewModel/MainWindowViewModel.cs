using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.WPF.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRecipientsData _RecipientsData;


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

        public ObservableCollection<Recipient> Recipients { get; } = new ObservableCollection<Recipient>();

        private Recipient _SelectedRecipient;

        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }

        public ICommand LoadDataCommand { get; }

        public ICommand SaveRecipientCommand { get; }

        public MainWindowViewModel(IRecipientsData RecipientsData)
        {
            _RecipientsData = RecipientsData;


            LoadDataCommand = new RelayCommand(OnLoadDataCommandExecuted);
            SaveRecipientCommand = new RelayCommand<Recipient>(OnSaveRecipientCommandExecuted, CanSaveRecipientCommandExecute);
        }

        private void OnLoadDataCommandExecuted()
        {
            Recipients.Clear();
            foreach (var recipient in _RecipientsData.GetAll())
                Recipients.Add(recipient);
        }

        private void OnSaveRecipientCommandExecuted(Recipient recipient)
        {
            _RecipientsData.Edit(recipient);
        }

        private bool CanSaveRecipientCommandExecute(Recipient recipient) => recipient != null;
    }
}
