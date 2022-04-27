namespace LoggerApplication.Factories
{
    using System;
    using System.Globalization;

    using LoggerApplication.Exceptions;
    using LoggerApplication.Models.Contracts;
    using LoggerApplication.Models.Enums;
    using LoggerApplication.Models.Errors;

    public class ErrorFactory
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";

        public static IError GetError(string dateString, string levelString, string message)
        {
            ErrorLevel level;

            bool hasParsed = Enum.TryParse<ErrorLevel>(levelString, out level);

            if (!hasParsed)
            {
                throw new InvalidLevelTypeException();
            }

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new InvalidDateFormatException();
            }

            return new Error(dateTime, message, level);
        }
    }
}