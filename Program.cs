using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace employee_data_Xml_format
{

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter employee id:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter employee name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter employee designation:");
            string designation = Console.ReadLine();

            Console.WriteLine("Enter employee salary:");
            int salary = Convert.ToInt32(Console.ReadLine());

            Employee employee = new Employee
            {
                Id = id,
                Name = name,
                Designation = designation,
                Salary = salary
            };
            string path = @"D:\EQ SOFT\C#\employee.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, employee);
            }

            Console.WriteLine("\nEmployee details have been successfully saved to " + path);

            Employee readEmployee;
            using (StreamReader reader = new StreamReader(path))
            {
                readEmployee = (Employee)serializer.Deserialize(reader);
            }

            Console.WriteLine("\nContent read from file:");
            Console.WriteLine($"Employee ID: {readEmployee.Id}");
            Console.WriteLine($"Employee Name: {readEmployee.Name}");
            Console.WriteLine($"Employee Designation: {readEmployee.Designation}");
            Console.WriteLine($"Employee Salary: {readEmployee.Salary}");

            Console.ReadLine();
        }
    }


}
  