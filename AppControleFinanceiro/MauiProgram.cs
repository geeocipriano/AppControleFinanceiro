﻿using AppControleFinanceiro.Repositories;
using LiteDB;
using Microsoft.Extensions.Logging;

namespace AppControleFinanceiro
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterDatabaseAndRepositories();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        // Injeção de dependencia do banco de dados
        // Acoplando a injeção de dependencia dos repositorios em um unico metodo
        public static MauiAppBuilder RegisterDatabaseAndRepositories(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<LiteDatabase>(
                options => {
                    return new LiteDatabase($"Filename={AppSettings.DatabasePath};Connection=Shared");
                }
            );
            mauiAppBuilder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
            return mauiAppBuilder;
        }
    }
}
