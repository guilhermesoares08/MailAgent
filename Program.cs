using Microsoft.Extensions.Configuration;
using System;

namespace MailAgent
{
    public class Program
    {
        static void Main(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"C:\\Users\\Guilherme\\source\\repos\\MailAgent\\appsettings.json", true, true)
                .AddEnvironmentVariables();
            
            var config = builder.Build();

            var listOfEmails = FileHelper.ReadEmailsFromExcel(config["FileLocation"]);

            MailHelper.Send(config["MailSettings:Credentials:UserName"], config["MailSettings:Credentials:Password"], listOfEmails);
        }
    }
}
