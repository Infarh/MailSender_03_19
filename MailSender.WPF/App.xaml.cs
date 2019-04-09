using System.Windows;

namespace MailSender.WPF
{
    public partial class App
    {
        public static bool IsInDebugModel { get; private set; } = true;

        protected override void OnStartup(StartupEventArgs e)
        {
            IsInDebugModel = false;
            base.OnStartup(e);
        }
    }
}
