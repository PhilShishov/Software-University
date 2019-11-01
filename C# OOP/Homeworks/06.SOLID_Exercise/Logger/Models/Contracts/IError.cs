namespace LoggerApplication.Models.Contracts
{
    using System;

    using LoggerApplication.Models.Enums;

    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        ErrorLevel Level { get; }
    }
}