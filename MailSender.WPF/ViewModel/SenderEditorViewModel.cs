using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Entityes;
using MailSender.WPF.Infrastructure;

namespace MailSender.WPF.ViewModel
{
    class SenderEditorViewModel : ViewModelBase, ICloseNotification
    {
        public event EventHandler<EventArgs<bool>> Closed;
        private void OnClosed(EventArgs<bool> e) => Closed?.Invoke(this, e);
        public void OnViewClosed(object sender, EventArgs e)
        {
            
        }

        private int _Id;

        public int Id
        {
            get => _Id;
            set => HasChanges |= Set(ref _Id, value);
        }

        private string _Name;

        public virtual string Name
        {
            get => _Name;
            set => HasChanges |= Set(ref _Name, value);
        }

        private string _EmailAddress;

        public virtual string EmailAddress
        {
            get => _EmailAddress;
            set => HasChanges |= Set(ref _EmailAddress, value);
        }

        #region HasChanges : bool - Изменения

        /// <summary>Изменения</summary>
        private bool _HasChanges;

        /// <summary>Изменения</summary>
        public bool HasChanges
        {
            get => _HasChanges;
            set => Set(ref _HasChanges, value);
        }

        #endregion


        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        public SenderEditorViewModel()
        {
            OkCommand = new RelayCommand(OnOkCommandExecuted);
            CancelCommand = new RelayCommand(OnCancelCommandExecuted);
        }

        private void OnOkCommandExecuted() => OnClosed(true);

        private void OnCancelCommandExecuted() => OnClosed(false);
    }
}
