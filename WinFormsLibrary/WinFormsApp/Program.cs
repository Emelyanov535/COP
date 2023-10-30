using BusinessLogic;
using Contracts.BusinessLogicContracts;
using Contracts.StoragesContracts;
using DataBase.Implements;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WinFormsApp
{
    internal static class Program
    {
        private static ServiceProvider? _serviceProvider;
        public static ServiceProvider? ServiceProvider => _serviceProvider;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
            Application.Run(_serviceProvider.GetRequiredService<FormMain>());
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<IManagerStorage, ManagerStorage>();
            services.AddTransient<IProviderStorage, ProviderStorage>();

            services.AddTransient<IManagerLogic, ManagerLogic>();
            services.AddTransient<IProviderLogic, ProviderLogic>();

            services.AddTransient<FormMain>();
            services.AddTransient<FormProvider>();
            services.AddTransient<FormManager>();
        }
    }
}