
namespace LoggerApplication
{
    using System;
    using System.Collections.Generic;

    using LoggerApplication.Core;
    using LoggerApplication.Factories;
    using LoggerApplication.Models.Contracts;
    using LoggerApplication.Models.Loggers;

    public class StartUp
    {
        public static void Main()
        {
            int countOfAppenders = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();
            AppenderFactory appenderFactory = new AppenderFactory();

            ReadAppendersData(countOfAppenders, appenders, appenderFactory);
            ILogger logger = new Logger(appenders);

            Engine engine = new Engine(logger);
            engine.Run();
        }

        private static void ReadAppendersData(int countOfAppenders,
            ICollection<IAppender> appenders,
            AppenderFactory appenderFactory)
        {
            for (int i = 0; i < countOfAppenders; i++)
            {
                var appendersInfo = Console.ReadLine().Split();

                string appenderType = appendersInfo[0];
                string layoutType = appendersInfo[1];
                string levelStr = "INFO";

                if (appendersInfo.Length == 3)
                {
                    levelStr = appendersInfo[2];
                }

                try
                {
                    IAppender appender = appenderFactory.GetAppender(appenderType, layoutType, levelStr);
                    appenders.Add(appender);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
