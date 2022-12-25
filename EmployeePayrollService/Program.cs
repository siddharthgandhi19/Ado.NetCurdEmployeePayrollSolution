using EmployeePayrollService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroleService
{
    public class Program
    {
        static void Main(string[] args)
        {
            Payroll payroll = new Payroll();
            bool flag = true;
            while (flag)
            {
                Console.Write(" 1.Display\n 2.Add\n 3.Update\n 4.Delete");
                int option = Convert.ToInt16(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        EmployeeRepository employeeRepositoryDisplay = new EmployeeRepository();
                        employeeRepositoryDisplay.GetAllEmployes();
                        break;
                    case 2:
                        Console.Write("Enter name : ");
                        payroll.EmpName = Console.ReadLine();
                        Console.Write("Enter Department name : ");
                        payroll.EmpDept = Console.ReadLine();
                        Console.Write("Enter salary : ");
                        payroll.EmpSalary = Convert.ToInt64(Console.ReadLine());
                        EmployeeRepository employeeRepositoryAdd = new EmployeeRepository();
                        employeeRepositoryAdd.AddEmployee(payroll);
                        break;
                    case 3:
                        Console.Write("Enter Id : ");
                        payroll.EmpId = Convert.ToInt16(Console.ReadLine());
                        Console.Write("Enter name : ");
                        payroll.EmpName = Console.ReadLine();
                        Console.Write("Enter Department name : ");
                        payroll.EmpDept = Console.ReadLine();
                        Console.Write("Enter salary : ");
                        payroll.EmpSalary = Convert.ToInt64(Console.ReadLine());
                        EmployeeRepository employeeRepositoryUpdate = new EmployeeRepository();
                        employeeRepositoryUpdate.UpdateEmployee(payroll);
                        break;
                    case 4:
                        Console.Write("Enter Employee id to delte : ");
                        int employeeIdForDelete = Convert.ToInt16(Console.ReadLine());
                        EmployeeRepository employeeRepositoryDelete = new EmployeeRepository();
                        employeeRepositoryDelete.DeleteEmployee(employeeIdForDelete);
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}
