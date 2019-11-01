namespace LoggerApplication.Models.Appenders
{
    using LoggerApplication.Models.Contracts;
    using LoggerApplication.Models.Enums;
    using System;

    public class FileAppender : Appender
    {
        public FileAppender()
        {
        }

        public FileAppender(ILayout layout, ErrorLevel level, IFile file) 
            : base(layout, level)
        {
            this.File = file;
        }

        public IFile File { get; private set; }

        public override void Append(IError error)
        {
            string formattedMessage = this.File
                .Write(this.Layout, error) + Environment.NewLine;

            System.IO.File.AppendAllText(this.File.Path, formattedMessage);

            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size {this.File.Size}";
        }
    }
}
