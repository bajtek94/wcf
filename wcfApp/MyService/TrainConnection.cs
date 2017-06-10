using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyService
{
    [Serializable]
    public class TrainConnection
    {
        public string City1 { get; set; }
        public string City2 { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TrainConnection(string city1, string city2, string startTime, string endTime)
        {
            City1 = city1;
            City2 = city2;
            StartTime = DateTime.ParseExact(startTime, "yyyy-MM-dd HH:mm", null);
            EndTime = DateTime.ParseExact(endTime, "yyyy-MM-dd HH:mm", null);
        }
        
    }
}
