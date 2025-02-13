using System;
using EmployeeLibrary;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1) Add Employees ");
            Console.WriteLine("2) View all Employees ");
            Console.WriteLine("3) Search Employees by Name ");
            Console.WriteLine("4) Sercah Employees by salary range ");
            Console.WriteLine("5) Exit ");
            int choice;
            Console.WriteLine("Enter your choice : ");
            choice = int.Parse(Console.ReadLine());
            EmployeeManager mgr = new EmployeeManager();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter name :");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter address :");
                    string address = Console.ReadLine();
                    Console.WriteLine("Enter salary :");
                    float salary = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter tax :");
                    float tax = float.Parse(Console.ReadLine());

                    Employee emp = new Employee(name, address, salary, tax);
                    mgr.Save(emp);
                    Console.WriteLine("Employee saved successfully!");
                    break;
                case 2:
                    List<Employee> list = new List<Employee>();
                    list = mgr.ReadAll();
                    if (list == null)
                    {
                        Console.WriteLine("No employees found ");
                    }
                    else
                    {
                        foreach (Employee empl in list)
                        {
                            Console.WriteLine(empl);
                        }
                    }
                    break;

                case 3:
                    Console.WriteLine("Enter name :");
                    string searchname = Console.ReadLine();
                    Employee namedEmp = new Employee();

                    List<Employee> employees = new List<Employee>();
                    employees = mgr.SearchEmployeebyName(searchname);

                    if (employees == null)
                    {
                        Console.WriteLine("No employees found ");
                    }
                    else
                    {
                        Console.WriteLine("Employee details: ");
                        foreach (Employee empl in employees)
                        {
                            Console.WriteLine(empl);
                        }
                    }
                    break;

                case 4:
                    Console.WriteLine("Enter lower range : ");
                    float lower = float.Parse( Console.ReadLine());

                    Console.WriteLine("Enter upper range : ");
                    float upper = float.Parse(Console.ReadLine());

                    List<Employee> salemployees = new List<Employee>();
                    salemployees = mgr.SearchEmployeebyRange(lower, upper);

                    if (salemployees == null)
                    {
                        Console.WriteLine("No employees found ");
                    }
                    else
                    {
                        Console.WriteLine("Employee details: ");
                        foreach (Employee empl in salemployees)
                        {
                            Console.WriteLine(empl);
                        }
                    }
                    break;

                case 5:
                    Console.WriteLine("Exiting the program !");
                    break;

                default:
                    Console.WriteLine("Choice is invalid, Try again !");
                    break;
            }
        }
    }
}