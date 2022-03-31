using System;
using System.IO;

namespace Generic
{
    class LocalFileLogger<T> : ILogger
    {

        private readonly string path_;

        public LocalFileLogger(string PathToFile)
        {
            this.path_ = PathToFile;
        }

        public void LogInfo(string message)
        {
            File.AppendAllText(path_, $"[Info]: [{typeof(T).Name}] : {message}" + "\n");
        }

        public void LogWarning(string message)
        {
            File.AppendAllText(path_, $"[Warning] : [{typeof(T).Name}] : {message}" + "\n");
        }

        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(path_, $"[Error] : [{typeof(T).Name}] : {message}. {ex.Message}" + "\n");
        }
    }
}
