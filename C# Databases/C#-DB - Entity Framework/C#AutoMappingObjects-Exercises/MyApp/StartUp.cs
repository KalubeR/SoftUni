using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core;
using MyApp.Core.Contracts;
using MyApp.Data;

namespace MyApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider provider = ConfigureServices();
            IEngine engine = new Engine(provider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<MyAppContext>(db =>
                db.UseSqlServer(@"Server=DESKTOP-M55K9NF\SQLEXPRESS;Database=MyApp;Integrated Security=True"));

            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();

            serviceCollection.AddTransient<Mapper>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
