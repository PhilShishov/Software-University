namespace LoggerApplication.Models.Contracts
{
    public interface IIOManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        void EnsureDirectoryAndFileExists();

        string GetCurrentPath();
    }
}