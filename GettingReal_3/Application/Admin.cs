using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_3
{
    public class Admin
    {
        EmployeeRepository RepoEmp = new EmployeeRepository();
        SQL sql = new SQL();
        Shift shift = new Shift();
        AdminEmployee adminEmp = new AdminEmployee();
        Employee e = new Employee();
        public void AddEmployee()
        {
            RepoEmp.AddEmployee();
            Console.Clear();
        }

        public void RemoveEmployee()
        {
            RepoEmp.RemoveEmployee();
        }


        public void PlanShift()
        {
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
            

            StringBuilder dato = adminEmp.InputDateTime("../..", '/', "Registrer en vagt. Skriv som DD/MM: \n");

            string ShiftDate = dato.ToString();
            string day = dato[0].ToString() + dato[1].ToString();
            string month = dato[3].ToString() + dato[4].ToString();

            //for at tjekke om det er en rigtig dato:
            int dayAsNum = int.Parse(day);
            int monthAsNum = int.Parse(month);

            DateTime dag = new DateTime();
            if (monthAsNum <= 12 && monthAsNum >= 1 && dayAsNum <= 31 && dayAsNum >= 1)
            {
                dag = DateTime.Parse(ShiftDate);
                //ind til property:
                e.ShiftDate = dag;
            }

            
            Console.WriteLine("intast morgen eller aften: ");
            string morgenAften = Console.ReadLine();
            morgenAften.ToLower();

            while (!morgenAften.Equals("morgen") && !morgenAften.Equals("aften"))
            {
                Console.WriteLine("Du har intastet forkert, prøv igen: ");
                morgenAften = Console.ReadLine();
            }

            Console.Write("Indtast navn: ");
            string input = Console.ReadLine();

            //tjekker i databasen om det er rigtigt navn
            while (sql.CheckEmployee(input) == null)
            {
                Console.Clear();
                Console.WriteLine("Du har intastet forkert navn, prøv igen: ");
                input = Console.ReadLine();
            }
            //insætter til property
            //dataBase.CheckEmployee(input).Name = input;

            sql.PlanShift(butikInput, e.ShiftDate, morgenAften, sql.CheckEmployee(input).EmployeeName);

            Console.WriteLine("Vagt planlagt");
        }
        


    }
}

