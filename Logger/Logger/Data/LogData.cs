using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Data
{
    internal static class LogData
    {
        public static Dictionary<DateTime, string> Logs { get; set; } = new Dictionary<DateTime, string>();
    }
}
