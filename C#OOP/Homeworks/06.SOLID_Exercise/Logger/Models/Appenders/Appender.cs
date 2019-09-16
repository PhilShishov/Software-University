namespace LoggerApplication.Models.Appenders
{
    using LoggerApplication.Models.Contracts;
    using LoggerApplication.Models.Enums;

    public abstract class Appender : IAppender
    {
        private const string dateFormat = "M/dd/yyyy h:mm::ss tt";

        public Appender()
        {
            this.MessagesAppended = 0;
        }

        public Appender(ILayout layout, ErrorLevel level)
            : this()
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; private set; }

        public ErrorLevel Level { get; private set; }

        public string DateFormat => dateFormat;

        public int MessagesAppended { get; set; }

        public abstract void Append(IError error);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, " +
                $"Layout type: {this.Layout.GetType().Name}, Report level: " +
                $"{this.Level.ToString()}, Messages appended: {this.MessagesAppended}";
        }
    }
}
