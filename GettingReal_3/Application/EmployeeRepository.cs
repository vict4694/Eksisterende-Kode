﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_3
{
    public class EmployeeRepository
    {
        SQL sql = new SQL();

        
        public void AddEmployee()
        {
            Console.WriteLine("Navn på ny medarbejder: ");
            string empName = Console.ReadLine();

            sql.InsertToEmployee(empName);
            
            Console.WriteLine("Medarbejder tilføjet");
            
        }

        public void RemoveEmployee()
        {
            Console.Write("Navn på slet af employee: ");
            string empName = Console.ReadLine();
            
            sql.DeleteEmployee(empName);

            Console.WriteLine("Medarbejder er nu blevet slettet");
            Console.ReadKey();
        }
        
    }
}
