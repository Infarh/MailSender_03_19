using System;
using System.Windows;

using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MailSender.WPF.Test
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;

            button.IsEnabled = false;

            var progress_reporter = new Progress<int>(p => ProgressBlock.Text = p.ToString());

            var task = Task.Run(() => ComputeOperation(700, progress_reporter));

            var result = await task;

            button.IsEnabled = true;

            ProgressBlock.Text = $"Result = {result}";
        }

        private long ComputeOperation(int N = 1000, IProgress<int> progress = null)
        {
            long result = 0;
            for (var i = 0; i < N; i++)
            {
                Thread.Sleep(10);
                result += i;
                progress?.Report(i);
            }

            return result;
        }
    }
}
