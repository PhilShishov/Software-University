namespace LoggerApplication.Core
{
    using System;

    using LoggerApplication.Core.Contracts;
    using LoggerApplication.Factories;
    using LoggerApplication.Models.Contracts;

    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly ErrorFactory errorFactory;

        public Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger)
            : this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                var errorArgs = command.Split("|");

                string level = errorArgs[0];
                string date = errorArgs[1];
                string message = errorArgs[2];

                IError error;

                try
                {
                    error = this.errorFactory.GetError(date, level, message);
                    this.logger.Log(error);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);                    
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(this.logger.ToString());
        }
    }
}
