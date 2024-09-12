using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP_03._TCP_Task_Manger_Client
{
    internal class Command
    {
        public const string ProccessList = "PROCLIST";
        public const string Kill = "KILL";
        public const string Run = "RUN";
        public string? Text { get; set; }
        public string? Param { get; set; }
    }
}
