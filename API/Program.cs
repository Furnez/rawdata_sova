using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> DbParams = new List<string>();
            string[] ParamsQA = { "Connection name (ex: localhost, 192.xxx.xxx.xxx, etc ...) : ", "DataBase name : ", "User id : ", "Password : " };
            string conf = File.ReadAllText("db.conf");
            string input;
            int index = 1;

            Console.Write(ParamsQA[0]);
            while (!string.IsNullOrEmpty(input = Console.ReadLine()) && index < ParamsQA.Count())
            {
                Console.Write(ParamsQA[index]);
                DbParams.Add(input);
                index++;
            }
            DbParams.Add(input); // used to add the last input

            conf = conf.Replace(conf,
                "connection=" + DbParams[0] +
                "\ndbname=" + DbParams[1] +
                "\nuid=" + DbParams[2] +
                "\npwd=" + DbParams[3]
             );
            File.WriteAllText("db.conf", conf.Trim());

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
