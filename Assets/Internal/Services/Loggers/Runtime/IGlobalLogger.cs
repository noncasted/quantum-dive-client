namespace Internal.Services.Loggers.Runtime
{
    public interface IGlobalLogger
    {
        void Log(string message);
        void Log(string header, string message);
        void Log(string message, LogParameters parameters);
        void Warning(string warning);
        void Error(string error);
        void Error(string error, LogParameters parameters);
    }
}