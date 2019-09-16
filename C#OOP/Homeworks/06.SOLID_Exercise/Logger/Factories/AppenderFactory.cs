namespace LoggerApplication.Factories
{
    using System;

    using LoggerApplication.Exceptions;
    using LoggerApplication.Models.Appenders;
    using LoggerApplication.Models.Contracts;
    using LoggerApplication.Models.Enums;
    using LoggerApplication.Models.Files;


    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender(string appenderType, string layoutType, string levelStr)
        {
            ErrorLevel level;

            bool hasParsed = Enum.TryParse<ErrorLevel>(levelStr, out level);

            if (!hasParsed)
            {
                throw new InvalidLevelTypeException();
            }

            ILayout layout = this.layoutFactory.GetLayout(layoutType);            

            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }

            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile();
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidAppenderTypeException();
            }

            return appender;
        }
    }
}
