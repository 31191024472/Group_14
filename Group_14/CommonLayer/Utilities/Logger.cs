using System;
using System.IO;

namespace Group_14.CommonLayer.Utilities
{
    public static class Logger
    {
        private static readonly string logFilePath = "logs.txt";

        public static void Log(string message)
        {
            string logMessage = $"{DateTime.Now}: {message}";
            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }

        public static void LogError(Exception ex)
        {
            string errorMessage = $"{DateTime.Now}: ERROR - {ex.Message}";
            File.AppendAllText(logFilePath, errorMessage + Environment.NewLine);
        }
    }
}
