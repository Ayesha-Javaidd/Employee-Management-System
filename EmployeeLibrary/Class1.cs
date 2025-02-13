using System.Collections.Generic;
using System.IO;
namespace EmployeeLibrary
{
    public class Employee
    {
        String name;
        String address;
        float salary;
        float tax;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Address
        {
            get { return address; }
            set { address = value; }
        }
        public float Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public float Tax
        {
            get { return tax; }
            set { tax = value; }
        }

        public override String ToString()
        {
            return $"Name : {name} , Address : {address}, Salary : {salary}, Tax : {tax}";
        }

        public Employee()
        {
        }

        public Employee(string name, string address, float salary, float tax)
        {
            this.name = name;
            this.address = address;
            this.salary = salary;
            this.tax = tax;
        }
    }


    public class EmployeeManager
    {
        public void Save(Employee emp)
        {         
            FileStream fin = new FileStream("input.txt", FileMode.Append);
            StreamWriter fout = new StreamWriter(fin);
           
            fout.WriteLine($"{emp.Name},{emp.Address},{emp.Salary},{emp.Tax}");
            fout.Close();
            fin.Close();
        }
        public List<Employee> ReadAll()
        {
            List<Employee> list = new List<Employee>();
            FileStream fin = new FileStream("input.txt", FileMode.Open);
            StreamReader fout = new StreamReader(fin);

            if (!File.Exists("input.txt"))
            {
                Console.WriteLine("File not found");
                return list;
            }

            String line;
            while((line = fout.ReadLine()) != null)
            {
                String[] data = line.Split(',');
                if (data.Length == 4)
                {
                    Employee emp = new Employee(data[0], data[1], float.Parse(data[2]), float.Parse(data[3]));
                    list.Add(emp);
                }
            }
            fin.Close() ;
            fout.Close();
            return list;
        }

        public List<Employee> SearchEmployeebyName(String name)
        {
            if (!File.Exists("input.txt"))
                return null;

            FileStream fin = new FileStream("input.txt", FileMode.Open);
            StreamReader fout = new StreamReader(fin);
            String line;
            List<Employee> list = new List<Employee>();
            while ((line = fout.ReadLine()) != null)
            {
                String[] data = line.Split(',');
                if (data[0] == name)
                {
                    Employee employee = new Employee(data[0], data[1], float.Parse(data[2]), float.Parse(data[3]));
                   list.Add((employee));
                }
            }
            fin.Close();
            fout.Close();

            return list;
        }


        public List<Employee> SearchEmployeebyRange(float lower, float upper)
        {
            if (!File.Exists("input.txt"))
                return null;

            FileStream fin = new FileStream("input.txt", FileMode.Open);
            StreamReader fout = new StreamReader(fin);
            String line;
            List<Employee> list = new List<Employee>();
            while ((line = fout.ReadLine()) != null)
            {
                String[] data = line.Split(',');
                if (int.Parse(data[2]) >= lower && int.Parse(data[2]) <= upper)
                {
                    Employee emp = new Employee(data[0], data[1], float.Parse(data[2]), float.Parse(data[3]));
                    list.Add(emp);
                }
            }
            return list;
            fin.Close();
            fout.Close();
        }
    }
}