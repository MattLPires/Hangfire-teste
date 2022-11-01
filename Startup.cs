using Hangfire;
using Microsoft.AspNetCore.Builder;

namespace Empresa.Projeto.Demo.Hangfire
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(@"Data Source=PAX00879\SQLEXPRESS01;Initial Catalog=demo;Integrated Security=True;Pooling=False");

            //Fire and forget

            BackgroundJob.Enqueue(() => FireAndForget());

            //Scheduled jobs
            BackgroundJob.Schedule(() => Console.WriteLine("Teste Schedule"), TimeSpan.FromMilliseconds(10000));

            //Recurring jobs
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Teste Recurring Job"), Cron.Minutely);

            
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }

        public void FireAndForget()
        {
            Thread.Sleep(10000);
            Console.WriteLine("Teste Fire and Forget");
        }
    }
}
