using System;
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
            var services = SimpleIoc.Default;
            ServiceLocator.SetLocatorProvider(() => services);

            services
                .TryRegister<IRecipientsData, RecipientsDataLinq2Sql>()
                .TryRegister<ISendersData, SendersDataInMemory>()
                .TryRegister<IEmailsData, EmailsDataInMemory>()
                .TryRegister<IServersData, ServersDataInMemory>();

            services
                .TryRegister(() => new MailSenderDBDataContext())
                .TryRegister<MainWindowViewModel>();
        }


        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }

    internal static class SimpleIocExtensions
    {
        public static SimpleIoc TryRegister<TInterface, TClass>(this SimpleIoc services)
            where TInterface : class
            where TClass : class, TInterface
        {
            if (services.IsRegistered<TInterface>()) return services;
            services.Register<TInterface, TClass>();
            return services;
        }

        public static SimpleIoc TryRegister<TClass>(this SimpleIoc services)
            where TClass : class
        {
            if (services.IsRegistered<TClass>()) return services;
            services.Register<TClass>();
            return services;
        }

        public static SimpleIoc TryRegister<TClass>(this SimpleIoc services, Func<TClass> Factory)
            where TClass : class
        {
            if (services.IsRegistered<TClass>()) return services;
            services.Register(Factory);
            return services;
        }
    }
}