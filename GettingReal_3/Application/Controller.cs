using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_3
{
    public class Controller
    {
        public void RegisterHoursMenu()
        {
             EmployeeRepository empr = new EmployeeRepository();
            empr.RegisterHoursMenu();
        }
        public void EndedShifts()
        {
            AdminEmployeeRepo admEmp = new AdminEmployeeRepo();
            admEmp.EndedShifts();
        }
        public void PlanShift()
        {
            Admin admin = new Admin();
            admin.PlanShift();
        }
    }
}
