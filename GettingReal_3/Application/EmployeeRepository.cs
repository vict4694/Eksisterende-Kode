using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_3
{
    public class EmployeeRepository
    {
        AdminEmployeeRepo admEmp = new AdminEmployeeRepo();
        SQL sql = new SQL();
        Shift shift = new Shift();


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
        public void RegisterHoursMenu()
        {
            Console.Clear();


            Console.Write("Indtast navn: ");
            string input = Console.ReadLine();

            while (sql.CheckEmployee(input) == null)
            {
                Console.Clear();
                Console.WriteLine("Du har intastet forkert navn, prøv igen: ");
                input = Console.ReadLine();

            }

            Console.Clear();
            Console.WriteLine("Du har valgt: " + input);
            Console.WriteLine("Butikker: ");

            shift.AddStore();
            shift.ShowStores();

            Console.WriteLine("skriv butik navn: ");
            string butikInput = Console.ReadLine();

            while (shift.CheckStore(butikInput) == null)
            {
                Console.WriteLine("Du har intastet forkert butik navn, prøv igen: ");
                butikInput = Console.ReadLine();
            }
            shift.CheckStore(butikInput).StoreName = butikInput;

            Console.Clear();
            Console.WriteLine("du har valgt " + butikInput + "-butikken");


            admEmp.RegisterHours(sql.CheckEmployee(input), shift.CheckStore(butikInput));
        }
    }
}
