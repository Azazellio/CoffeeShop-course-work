using System;
using System.Collections.Generic;
using System.Windows;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CoffeeShop.DAO.Impl.DataContext;
using Microsoft.Extensions.Hosting;

namespace CoffeeshopWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        //private readonly IHost host;
        //public IServiceProvider ServiceProvider { get; private set; }
        public void ConfigureServices(IServiceCollection services)
        => services.AddDbContext<CoffeeShopAppContext>();
        //public static IHostBuilder CreateHostBuilder(string[] args)
        //=> Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }
}
