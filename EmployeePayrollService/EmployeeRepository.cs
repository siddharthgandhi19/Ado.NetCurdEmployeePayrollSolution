using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeeRepository
    {
        public static string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Emp_Payroll";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        //Display all employees
        public void GetAllEmployes()
        {
            try
            {
                List<Payroll> payroles = new List<Payroll>();
                using (this.sqlConnection)
                {
                    this.sqlConnection.Open();
                    string query = @"SELECT * FROM EmpDetails";
                    SqlCommand command = new SqlCommand(query, this.sqlConnection);
                    command.CommandType = System.Data.CommandType.Text;
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Payroll service = new Payroll();
                            service.EmpId = dr.GetInt32(0);
                            service.EmpName = dr.GetString(1);
                            service.EmpDept = dr.GetString(2);
                            service.EmpSalary = dr.GetInt64(3); ;
                            payroles.Add(service);
                        }
                    }
                    foreach (var data in payroles)
                    {
                        Console.WriteLine(data.EmpId + "  " + data.EmpName + " " + data.EmpDept + " " + data.EmpSalary);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //To Add Employee details    
        public void AddEmployee(Payroll obj)
        {
            this.sqlConnection.Open();
            SqlCommand com = new SqlCommand("AddNewEmpDetails", this.sqlConnection);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpsName", obj.EmpName);
            com.Parameters.AddWithValue("@EmpsDept", obj.EmpDept);
            com.Parameters.AddWithValue("@EmpsSalary", obj.EmpSalary);
            int i = com.ExecuteNonQuery();
            this.sqlConnection.Close();
            if (i >= 1)
                Console.WriteLine("Added successfully.");
            else
                Console.WriteLine("Retry. Emp id : " + obj.EmpId + " is not found ");
        }

        //To Update Employee details    
        public void UpdateEmployee(Payroll obj)
        {
            this.sqlConnection.Open();
            SqlCommand com = new SqlCommand("UpdateEmpDetails", this.sqlConnection);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpsId", obj.EmpId);
            com.Parameters.AddWithValue("@EmpsName", obj.EmpName);
            com.Parameters.AddWithValue("@EmpsDept", obj.EmpDept);
            com.Parameters.AddWithValue("@EmpsSalary", obj.EmpSalary);
            int i = com.ExecuteNonQuery();
            this.sqlConnection.Close();
            if (i >= 1)
                Console.WriteLine("Updated successfully.");
            else
                Console.WriteLine("Retry. Emp id : " + obj.EmpId + " is not found ");
        }

        //To delete Employee details    
        public void DeleteEmployee(int Id)
        {
            try
            {
                using (this.sqlConnection)
                {
                    this.sqlConnection.Open();
                    SqlCommand com = new SqlCommand("DeleteEmpDetails", this.sqlConnection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@EmpsId", Id);
                    int i = com.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (i >= 1)
                        Console.WriteLine("Deleted successfully.");
                    else
                        Console.WriteLine("Retry. Emp id : " + Id + " is not found ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

