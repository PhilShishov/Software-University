namespace LoggerApplication.Models.Files
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using LoggerApplication.Models.Contracts;
    using LoggerApplication.Models.Enums;
    using LoggerApplication.Models.IOManagement;

    public class LogFile : IFile
    {
        private const string dateFormat = "M/dd/yyyy h:mm::ss tt";

        private const string currentDirectory = "\\logs\\";
        private const string currentFile = "log.txt";

        private string currentPath;
        private IIOManager IOManager;

        public LogFile()
        {
            this.IOManager = new IOManager(currentDirectory, currentFile);
            this.currentPath = this.IOManager.GetCurrentPath();
            this.IOManager.EnsureDirectoryAndFileExists();
            this.Path = currentPath + currentDirectory + currentFile;
        }

        public string Path { get; private set; }

        public ulong Size => GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            ErrorLevel level = error.Level;
            string message = error.Message;   

            string formattedMessage = String.Format(format, 
                dateTime.ToString(dateFormat, CultureInfo.InvariantCulture),
                level.ToString(),
                message);

            return formattedMessage;
        }

        private ulong GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            ulong size = (ulong)text
                .ToCharArray()
                .Where(c => Char.IsLetter(c))
                .Sum(c => (int)c);

            return size;
        }
    }
}
