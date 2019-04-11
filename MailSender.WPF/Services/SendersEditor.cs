using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;
using MailSender.WPF.Infrastructure;
using MailSender.WPF.ViewModel;
using MailSender.WPF.Views;

namespace MailSender.WPF.Services
{
    class EntityEditorService : IEntityEditor
    {
        public bool Edit(Sender sender)
        {
            var model = new SenderEditorViewModel
            {
                Id = sender.Id,
                Name = sender.Name,
                EmailAddress = sender.EmailAddress 
            };
            var view = new SenderEditorView { DataContext = model };
            view.Closed += model.OnViewClosed;

            model.Closed += OnModelClosed;
            void OnModelClosed(object s, EventArgs<bool> e)
            {
                model.Closed -= OnModelClosed;
                view.Closed -= OnWindowClosed;
                view.Closed -= model.OnViewClosed;
                view.DialogResult = e.Arg;
                view.Close();
            }

            view.Closed += OnWindowClosed;
            void OnWindowClosed(object s, EventArgs e)
            {
                model.Closed -= OnModelClosed;
                view.Closed -= OnWindowClosed;
                view.Closed -= model.OnViewClosed;
            }

            if(view.ShowDialog() != true || !model.HasChanges) return false;

            sender.Name = model.Name;
            sender.EmailAddress = model.EmailAddress;

            return true;
        }
    }
}
