using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_3
{
    public class Employee
    {
        private string name;
        public Employee(string name)
        {
            EmployeeName = name;
        }
        public Employee() { }
        public string EmployeeName
        {
            get { return name; }
            set { name = value; }
        }
        public DateTime ShiftDate { get; set; }

        private TimeSpan timespan = new TimeSpan(00, 00, 00);
        
        public TimeSpan TotalHoursWorked
        {
            get { return timespan; }
            set { this.timespan = value; }
        }

        public double TotalHoursToDouble()
        {
            double min = this.timespan.TotalMinutes;
            double hours = min / 60;
            return hours;
        }
    }
}
