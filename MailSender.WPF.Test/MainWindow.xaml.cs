using System;
using System.Windows;

using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MailSender.WPF.Test
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private Thread _ComputeThread;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(_ComputeThread != null) return;
            ((Button) sender).IsEnabled = false;
            _ComputeThread = new Thread(ComputeOperation);
            _ComputeThread.Start();
        }

        private bool _CanWork = true;
        private void ComputeOperation()
        {
            for (var i = 0; i < 1000 && _CanWork; i++)
            {
                //Application.Current.Dispatcher.Invoke(() =>
                //{
                //    ProgressBlock.Text = $"Progress {i}";
                //});

                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(() =>
                    {
                        ProgressBlock.Text = $"Progress {i}";
                    }));

                //ProgressBlock.Dispatcher.Invoke(() =>
                //{
                //    ProgressBlock.Text = $"Progress {i}";
                //});


                Thread.Sleep(100);
            }

            StartButton.Dispatcher.Invoke(() =>
            {
                StartButton.IsEnabled = true;
            });

            _ComputeThread = null;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            _CanWork = false;
            if(_ComputeThread != null && !_ComputeThread.Join(300))
                _ComputeThread.Abort();
        }
    }
}
