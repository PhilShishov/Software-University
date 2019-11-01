namespace LoggerApplication.Models.Appenders
{
    using System;
    using System.Globalization;

    using LoggerApplication.Models.Contracts;
    using LoggerApplication.Models.Enums;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender()
        {
        }

        public ConsoleAppender(ILayout layout, ErrorLevel level) 
            : base(layout, level)
        {
        }

        public override void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            ErrorLevel level = error.Level;
            string message = error.Message;

            string formattedMessage = String.Format(format,
                dateTime.ToString(base.DateFormat, CultureInfo.InvariantCulture),
                level.ToString(),
                message);

            Console.WriteLine(formattedMessage);
            base.MessagesAppended++;
        }        
    }
}
