using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal_3
{
    
    public class Menu
    {
        Admin admin = new Admin();
        AdminEmployeeRepo admEmp = new AdminEmployeeRepo();
        Shift shift = new Shift();
        Store store = new Store();
        EmployeeRepository empRepo = new EmployeeRepository();
        SQL dataBase = new SQL();
        Program program = new Program();
        Controller control = new Controller();

        public void Show()

        {
            bool active = true;
            do
            {
                Console.WriteLine("--------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"   _    _  ____  _   _  _   _");
                Console.WriteLine(@"  |  \/  || ___|| \ | || | | |");
                Console.WriteLine(@"  |      || |_ ||  \| || | | |");
                Console.WriteLine(@"  | |\/| ||  _|||     || | | |");
                Console.WriteLine(@"  | |  | || |__|| |\  || |_| |");
                Console.WriteLine(@"  |_|  |_||____||_| \_|\_____/");

                Console.ResetColor();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("\n--------------------------------");

                Console.WriteLine("Vælg punkt mellem 1-4");
                Console.WriteLine("1: Registrér timer");
                Console.WriteLine("2: Se dine afsluttede vagter");
                Console.WriteLine("3: Administration");
                Console.WriteLine("4: Luk ned");

                Console.WriteLine("--------------------------------");

                int switchCase = Convert.ToInt32(Console.ReadLine());
                switch (switchCase)
                {
                    case 1:

                        Console.Clear();
                        control.RegisterHoursMenu();
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Se afsluttede vagter for denne måned");
                        EndedShifts();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Administration");
                        Console.WriteLine("Indtast administratorkode: ");

                        AdminPass();

                        Console.Clear();

                        Console.WriteLine("Vælg mellem 1-5");
                        Console.WriteLine("1. Eksportér liste til Excel");
                        Console.WriteLine("2. Tilføj medarbejder");
                        Console.WriteLine("3. Slet medarbejder");
                        Console.WriteLine("4. Planlæg ny vagt");
                        Console.WriteLine("5. Luk ned");

                        Administration();

                        break;

                    case 4:
                        Environment.Exit(0);

                        break;
                }
            } while (active);
        }

        public void EndedShifts()
        {
            admEmp.EndedShifts();
        }

        public void Administration()
        {
            int s = Convert.ToInt32(Console.ReadLine());
            switch (s)
            {
                case 1:
                    Console.WriteLine("1. Eksportér liste til Excel");

                    break;


                case 2:
                    Console.WriteLine("3. Tilføj medarbejder");

                    admin.AddEmployee();
                    GoBack();
                    break;

                case 3:
                    Console.WriteLine("4. Slet medarbejder");

                    admin.RemoveEmployee();
                    GoBack();

                    break;
                case 4:
                    Console.WriteLine("5. Planlæg ny vagt");
                    PlanShift();
                    break;

                case 5:
                    Console.WriteLine("6. Luk ned");
                    Environment.Exit(0);
                    break;
            }
        }
        public void PlanShift()
        {
            admin.PlanShift();
        }

        public void AdminPass()
        {
            string password;
            int counter = 0, pw = 0;
            do
            {
                password = Console.ReadLine();
                if (password == "1234")
                {
                    pw = 1;
                    counter = 3;
                }

                else
                {
                    pw = 0;
                    counter++;
                }
            }
            while (password != "1234" && (counter != 3));

            if (pw == 0)
            {
                Console.WriteLine("Mere end 3 loginforsøg, prøv igen senere");
                Environment.Exit(0);
            }
            else
            if (pw == 1)
            {
                Console.WriteLine("Kodeord godkendt!");

            }
        }
        public void GoBack()
        {
            char s = Console.ReadKey().KeyChar;
            if (s.Equals('b'))
            {
                program.Run();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}

