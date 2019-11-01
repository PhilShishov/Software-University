namespace LoggerApplication.Models.Contracts
{
    using LoggerApplication.Models.Enums;

    public interface IAppender
    {
        ILayout Layout { get; }

        ErrorLevel Level { get; }

        void Append(IError error);
    }
}