namespace SecureUserManagement.Services
{
    public class LoggingService
    {
        private readonly string logFilePath = "Logs/app_log.txt";

        public void LogInfo(string message)
        {
            WriteLog("INFO", message);
        }

        public void LogError(string message, Exception ex)
        {
            WriteLog("ERROR", $"{message} | Exception: {ex.Message} | StackTrace: {ex.StackTrace}");
        }

        private void WriteLog(string type, string message)
        {
            Directory.CreateDirectory("Logs");

            string logMessage = $"{DateTime.Now} [{type}] {message}";

            using (StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                sw.WriteLine(logMessage);
            }
        }
    }
}