using Logger.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Models
{
    internal abstract class Log
    {
        //private Dictionary<DateTime, string> _logs = new Dictionary<DateTime, string>();
        private string _fileName;
        private SqlConnection _connection;
        protected Log (string fileName)
        {
            _fileName = fileName;
        }
        protected Log(SqlConnection connection)
        {
            _connection = connection;
        }
        public virtual void Write(string message)
        {
            LogData.Logs.Add(DateTime.Now, message);
            if (!string.IsNullOrEmpty(_fileName))
            {
                using (StreamWriter sw = new StreamWriter(_fileName, true))
                {
                    sw.WriteLine($"{DateTime.Now} \t {message}");
                }
            }
            if(_connection != null)
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO Logs (Date, Message) VALUES (@date, @message)", _connection))
                {
                    command.Parameters.AddWithValue("@date", DateTime.Now);
                    command.Parameters.AddWithValue("@message", message);
                    _connection.Open();
                    command.ExecuteNonQuery();
                    _connection.Close();
                }
            }
        }
        public abstract void DisplayLog();
    }
}
