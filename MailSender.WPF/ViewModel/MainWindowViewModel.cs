using System;
using System.CodeDom;
using System.Collections.Generic;
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
        private readonly IServersData _ServersData;
        private readonly IEmailsData _EmailsData;
        private readonly IEmailListsData _EmailListsData;
        private readonly ISchedulerTasksData _TasksData;
        private readonly ISendersData _SendersData;


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
        public ObservableCollection<Sender> Senders { get; } = new ObservableCollection<Sender>();
        public ObservableCollection<Server> Servers { get; } = new ObservableCollection<Server>();
        public ObservableCollection<SchedulerTask> Tasks { get; } = new ObservableCollection<SchedulerTask>();
        public ObservableCollection<Email> Emails { get; } = new ObservableCollection<Email>();
        public ObservableCollection<EmailList> EmailLists { get; } = new ObservableCollection<EmailList>();

        private Recipient _SelectedRecipient;

        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }

        public ICommand LoadDataCommand { get; }

        public ICommand SaveRecipientCommand { get; }

        public MainWindowViewModel(
            IRecipientsData RecipientsData,
            IServersData ServersData,
            IEmailsData MailsData,
            IEmailListsData EmailListsData,
            ISchedulerTasksData TasksData,
            ISendersData SendersData)
        {
            _RecipientsData = RecipientsData ?? throw new ArgumentNullException(nameof(RecipientsData));
            _ServersData = ServersData ?? throw new ArgumentNullException(nameof(ServersData));
            _EmailsData = MailsData ?? throw new ArgumentNullException(nameof(MailsData));
            _EmailListsData = EmailListsData ?? throw new ArgumentNullException(nameof(EmailListsData));
            _TasksData = TasksData ?? throw new ArgumentNullException(nameof(TasksData));
            _SendersData = SendersData ?? throw new ArgumentNullException(nameof(SendersData));

            LoadDataCommand = new RelayCommand(OnLoadDataCommandExecuted);
            SaveRecipientCommand = new RelayCommand<Recipient>(OnSaveRecipientCommandExecuted, CanSaveRecipientCommandExecute);
        }

        private void OnLoadDataCommandExecuted()
        {
            void RefreshData<T>(ICollection<T> items, IDataService<T> service)
            {
                items.Clear();
                foreach (var item in service.GetAll())
                    items.Add(item);
            }

            RefreshData(Recipients, _RecipientsData);
            RefreshData(Senders, _SendersData);
            RefreshData(Emails, _EmailsData);
            RefreshData(EmailLists, _EmailListsData);
            RefreshData(Tasks, _TasksData);
            RefreshData(Servers, _ServersData);
        }

        private void OnSaveRecipientCommandExecuted(Recipient recipient)
        {
            _RecipientsData.Edit(recipient);
        }

        private bool CanSaveRecipientCommandExecute(Recipient recipient) => recipient != null;
    }
}
