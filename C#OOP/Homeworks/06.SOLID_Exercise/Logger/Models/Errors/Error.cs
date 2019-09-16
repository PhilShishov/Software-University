namespace LoggerApplication.Models.Errors
{
    using System;

    using LoggerApplication.Models.Contracts;
    using LoggerApplication.Models.Enums;

    public class Error : IError
    {
        public Error(DateTime dateTime, string message, ErrorLevel level = ErrorLevel.INFO)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public ErrorLevel Level { get; }
    }
}
