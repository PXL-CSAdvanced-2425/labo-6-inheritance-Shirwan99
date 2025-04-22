using Logger.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Models
{
    internal class ErrorLog : Log 
    {
        public ErrorLog(SqlConnection connection) : base(connection)
        {
            
        }
        public override void DisplayLog()
        {
            foreach (var log in LogData.Logs)
            {
                if (log.Value.StartsWith("ERROR:"))
                {
                    Console.WriteLine($"{log.Key} \t {log.Value}");
                }
            }
        }
        public override void Write(string message)
        {
            base.Write("ERROR:" + message);
        }
    }
}
