using System;

namespace Generic
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Users\maxim\source\repos\Generic\Example.txt";

            var intLogger = new LocalFileLogger<int>(path);
            intLogger.LogInfo("LogInfo int.");
            intLogger.LogWarning("LogWarning int!");
            intLogger.LogError("LogError int", new Exception("Exception int."));

            var stringLogger = new LocalFileLogger<string>(path);
            stringLogger.LogInfo("LogInfo string.");
            stringLogger.LogWarning("LogWarning string!");
            stringLogger.LogError("LogError string", new Exception("Exception string."));

            var shareholderLogger = new LocalFileLogger<BankAccount>(path);
            shareholderLogger.LogInfo("LogInfo BankAccount.");
            shareholderLogger.LogWarning("LogWarning BankAccount!");
            shareholderLogger.LogError("LogError BankAccount", new Exception("Exception BankAccount."));
        }
    }
}