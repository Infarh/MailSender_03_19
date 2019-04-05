using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
using MailSender.lib.Entityes;

namespace MailSender.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для RecipientEditor.xaml
    /// </summary>
    public partial class RecipientEditor : UserControl
    {
        public RecipientEditor() => InitializeComponent();

        private void OnValidationError(object Sender, ValidationErrorEventArgs E)
        {
            if(!(E.Source is Control control)) return;

            if (E.Action == ValidationErrorEventAction.Added)
            {
                control.ToolTip = E.Error.ErrorContent.ToString();
            }
            else
            {
                control.ToolTip = "";
            }
        }
    }
}
