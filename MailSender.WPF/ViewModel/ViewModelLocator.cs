using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Data.linq2sql;
using MailSender.lib.Services;
using MailSender.lib.Services.Interfaces;

namespace MailSender.WPF.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<IRecipientsData, RecipientsDataLinq2Sql>();
            SimpleIoc.Default.Register(() => new MailSenderDBDataContext());
        }


        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}