using BankingDomain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankingKiosk
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            // Dependency Injection Framework or an Inversion of Control Framework
            // "Composition Root"
            var host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<Form1>();
                services.AddSingleton<BankAccount>();
                services.AddSingleton<IProvideTheBusinessClock, StandardBusinessClock>();
                services.AddSingleton<IDoBonusCalculations, StandardBonusCalculator>();
                services.AddSingleton<ISystemTime, SystemTime>();
                services.AddSingleton<INotifyTheFeds, IWillNotifyTheFedsForRealz>();

            }).Build();

            using var scope = host.Services.CreateScope();
            var magicFactory = scope.ServiceProvider;

            ApplicationConfiguration.Initialize();
            Application.Run(magicFactory.GetRequiredService<Form1>());
        }
    }

    public class IWillNotifyTheFedsForRealz : INotifyTheFeds
    {
        public void AccountWithdrawn(BankAccount bankAccount, decimal amountToWithdraw)
        {
            MessageBox.Show($"Notifying the feds of a withdraw of {amountToWithdraw:c}. Please stay in your seat and keep your hands visible");
        }
    }
}