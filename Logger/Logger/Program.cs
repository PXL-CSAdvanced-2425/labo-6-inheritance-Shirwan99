using Logger.Models;
using Microsoft.Data.SqlClient;

namespace Logger
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            //Log baseLog = new Log();
            //baseLog.Write("Basis message");

            ActivityLog activity = new ActivityLog("log.txt");
            activity.Write("Applicatie gestart");

            ErrorLog errorLog = new ErrorLog(new SqlConnection("log.txt"));
            errorLog.Write("Fout in applicatie");

            //baseLog.DisplayLog();
            activity.DisplayLog();
            //errorLog.DisplayLog();
        }
    }
}
