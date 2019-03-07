using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_3
{
    public class Shift
    {
        List<Store> storeList = new List<Store>();
        private DateTime day;
        private DateTime startTime;
        private DateTime endTime;
        private double timeSpanDouble;
        public void AddStore()
        {
            storeList = new List<Store>
            {
                new Store("ng"),
                new Store("tbt"),
            };
        }

        public Store CheckStore(string store)
        {
            foreach (Store item in storeList)
            {
                if (item.StoreName.Equals(store))
                {
                    return item;
                }
            }
            return null;
        }

        public void ShowStores()
        {
            for (int i = 0; i < storeList.Count; i++)
            {
                Console.WriteLine(i + 1 + ": " + storeList[i].StoreName.ToString());
            }
        }
        
        public DateTime Day { get { return day; } set { day = value; } }

        public DateTime StartTime { get { return startTime; } set { startTime = value; } }

        public DateTime EndTime { get { return endTime; } set { endTime = value; } }

        public double TimeSpanDouble { get { return timeSpanDouble; } set { timeSpanDouble = value; } }

        public TimeSpan Timer(string startDateString, string endDateString)
        {
            // string skal angives: 00/00/00 00:00:00
            
            DateTime startShift = DateTime.Parse(startDateString);
            DateTime endShift = DateTime.Parse(endDateString);
            TimeSpan interval = endShift - startShift;

            StartTime = startShift;
            EndTime = endShift;

            return interval;
            
        }
    }
}
