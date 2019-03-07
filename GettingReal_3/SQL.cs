using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace GettingReal_3
{
    public class SQL
    {
        private string connectionString = "Data Source= den1.mssql7.gear.host; Initial Catalog=gettingreal ; User Id=gettingreal; Password=Kx8ig9R5w~h-;";

        public void InsertToEmployee(string employeeName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    SqlCommand insertToEmployee = new SqlCommand("InsertToMedarbejder", conn);
                    insertToEmployee.CommandType = CommandType.StoredProcedure;
                    insertToEmployee.Parameters.Add(new SqlParameter("@Navn", employeeName));

                    insertToEmployee.ExecuteNonQuery();
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Insert to employee fejl" + e.Message);
                }
            }
        }
        public void DeleteEmployee(string employeeName)
        {
            if (CheckEmployee(employeeName) != null)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    try
                    {
                        SqlCommand deleteEmployee = new SqlCommand("DeleteEmployee", conn);
                        deleteEmployee.CommandType = CommandType.StoredProcedure;
                        deleteEmployee.Parameters.Add(new SqlParameter("@Medarbejder", employeeName));

                        deleteEmployee.ExecuteNonQuery();

                    }
                    catch (SqlException n)
                    {
                        Console.WriteLine("Feeeeeeeeeejl" + n.Message);

                    }
                }
            }
            else
            {
                Console.WriteLine("Forkert navn");
            }

        }

        public Employee CheckEmployee(string employeeName)
        {
            Employee empl = new Employee();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    SqlCommand checkEmployee = new SqlCommand("CheckMedarbejder", conn);
                    checkEmployee.CommandType = CommandType.StoredProcedure;
                    checkEmployee.Parameters.Add(new SqlParameter("@Medarbejder", employeeName));

                    string Medarbejder = checkEmployee.ExecuteScalar()?.ToString();
                    string lower = Medarbejder.ToLower();
                    string inputToLower = employeeName.ToLower();
                    
                    if (lower == inputToLower)
                    {
                        empl.EmployeeName = employeeName;
                        return empl;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (SqlException p)
                {
                    Console.WriteLine("Puha" + p.Message);
                    return null;
                }
            }
        }

        public void InsertToShift(string shopName, DateTime date, string morningAfternoon, string employee, DateTime shiftStart, DateTime shiftEnd, double numOfHours)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    SqlCommand insertToShift = new SqlCommand("IndsætVagt", conn);
                    insertToShift.CommandType = CommandType.StoredProcedure;
                    insertToShift.Parameters.Add(new SqlParameter("@ButikNavn", shopName));
                    insertToShift.Parameters.Add(new SqlParameter("@Dato", date));
                    insertToShift.Parameters.Add(new SqlParameter("@MorgenAften", morningAfternoon));
                    insertToShift.Parameters.Add(new SqlParameter("@Medarbejder", employee));
                    insertToShift.Parameters.Add(new SqlParameter("@startTid", shiftStart));
                    insertToShift.Parameters.Add(new SqlParameter("@slutTid", shiftEnd));
                    insertToShift.Parameters.Add(new SqlParameter("@antalTimer", numOfHours));
                    insertToShift.ExecuteNonQuery();
                    Console.Clear();
                    Console.WriteLine("Din vagt er Registreret");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Insert to shift fejl" + e.Message);
                }
            }


        }

        public void PlanShift(string shopName, DateTime date, string morningAfternoon, string employee)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    SqlCommand planShift = new SqlCommand("Planlæg", conn);
                    planShift.CommandType = CommandType.StoredProcedure;
                    planShift.Parameters.Add(new SqlParameter("@ButikNavn", shopName));
                    planShift.Parameters.Add(new SqlParameter("@Dato", date));
                    planShift.Parameters.Add(new SqlParameter("@MorgenAften", morningAfternoon));
                    planShift.Parameters.Add(new SqlParameter("@Medarbejder", employee));
                    planShift.ExecuteNonQuery();
                    Console.WriteLine("Vagten er planlagt");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("PlanShift virker ikke" + e.Message);
                }
                
            }
        }

        public void GetData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand getData = new SqlCommand("UdskrivVagt", conn))
                {
                    using (SqlDataReader reader = getData.ExecuteReader())
                    {
                        Console.WriteLine("ButikNavn" + GetNumberOfSpaces("ButikNavn") + "Dato" + GetNumberOfSpaces("Dato") +
                            "Morgen/Aften" + GetNumberOfSpaces("Morgen/Aften") +
                            "Medarbejder" + GetNumberOfSpaces("Medarbejder") + "Start Tid" + 
                            GetNumberOfSpaces("Start tid") + "SlutTid" + GetNumberOfSpaces("SlutTid") + "antal TImer\n");

                        while (reader.Read())
                        {
                            string Butiknavn = reader["ButikNavn"].ToString();
                            string Dato = reader["Dato"].ToString();
                            string MorgenAften = reader["MorgenAften"].ToString();
                            string Medarbejder = reader["Medarbejder"].ToString();
                            string StartTid = reader["StartTid"].ToString();
                            string SlutTid = reader["SlutTid"].ToString();
                            string AntalTimer = reader["AntalTimer"].ToString();
                            
                            
                            Console.WriteLine(Butiknavn + GetNumberOfSpaces(Butiknavn) + Dato + GetNumberOfSpaces(Dato) + MorgenAften 
                                + GetNumberOfSpaces(MorgenAften) + Medarbejder + GetNumberOfSpaces(Medarbejder) + StartTid + 
                                GetNumberOfSpaces(StartTid) + SlutTid + GetNumberOfSpaces(SlutTid) + AntalTimer);
                            

                        }
                    }
                }
            }
        }

        public void GetEmployeeData(string e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand getEmployeeData = new SqlCommand("UdskrivMedarbejderVagt", con);
                getEmployeeData.CommandType = CommandType.StoredProcedure;
                getEmployeeData.Parameters.Add(new SqlParameter("@Medarbejder", e));

                SqlDataReader reader = getEmployeeData.ExecuteReader();

                while (reader.Read())
                {
                    string Butiknavn = reader["ButikNavn"].ToString();
                    string Dato = reader["Dato"].ToString();
                    string MorgenAften = reader["MorgenAften"].ToString();
                    string Medarbejder = reader["Medarbejder"].ToString();
                    string StartTid = reader["StartTid"].ToString();
                    string SlutTid = reader["SlutTid"].ToString();
                    string AntalTimer = reader["AntalTimer"].ToString();


                    Console.WriteLine(Butiknavn + GetNumberOfSpaces(Butiknavn) + Dato + GetNumberOfSpaces(Dato) + MorgenAften
                        + GetNumberOfSpaces(MorgenAften) + Medarbejder + GetNumberOfSpaces(Medarbejder) + StartTid +
                        GetNumberOfSpaces(StartTid) + SlutTid + GetNumberOfSpaces(SlutTid) + AntalTimer);
                }
                Console.WriteLine();

            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand getEmployeeData = new SqlCommand("UdskrivAntalTimerArbejdet", conn);
                getEmployeeData.CommandType = CommandType.StoredProcedure;
                getEmployeeData.Parameters.Add(new SqlParameter("@Medarbejder", e));

                SqlDataReader reader = getEmployeeData.ExecuteReader();
                Console.Write("Antal timer arbejdet:\t");


                while (reader.Read())
                {
                    string AntalTimer = reader["AntalTimerArbejdet"].ToString();
                    Console.WriteLine(AntalTimer);
                }

            }
        }
        public string GetNumberOfSpaces(string columnText)
        {
            int i = 15 - columnText.Length;
            string spaces = new string(' ', i);
            return spaces;
        }

        
    }
}