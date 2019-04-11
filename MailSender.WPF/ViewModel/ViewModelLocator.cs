using System;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Data.linq2sql;
using MailSender.lib.Services;
using MailSender.lib.Services.Interfaces;
using MailSender.WPF.Services;

namespace MailSender.WPF.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var services = SimpleIoc.Default;
            ServiceLocator.SetLocatorProvider(() => services);

            services.TryRegister<MainWindowViewModel>();
            services.TryRegister<IRecipientsData, RecipientsDataLinq2Sql>();
            services.TryRegister(() => new MailSenderDBDataContext());
            services.TryRegister<IEntityEditor, EntityEditorService>();
        }


        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }

    internal static class SimpleIocExtensions
    {
        public static void TryRegister<TInterface, TClass>(this SimpleIoc services)
            where TInterface : class
            where TClass : class, TInterface
        {
            if(services.IsRegistered<TInterface>()) return;
            services.Register<TInterface, TClass>();
        }

        public static void TryRegister<TClass>(this SimpleIoc services)
            where TClass : class
        {
            if (services.IsRegistered<TClass>()) return;
            services.Register<TClass>();
        }

        public static void TryRegister<TClass>(this SimpleIoc services, Func<TClass> Factory)
            where TClass : class
        {
            if (services.IsRegistered<TClass>()) return;
            services.Register(Factory);
        }
    }
}