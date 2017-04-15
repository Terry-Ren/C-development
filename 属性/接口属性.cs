using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 属性
{
    class 接口属性
    {
        interface IEmployee         //这里是一个接口属性，在类中进行定义
        {
            string Name
            {
                get;
                set;
            }

            int Counter     //只写了get，说明他是一个只读属性
            {
                get;
            }
        }

        public class Employee : IEmployee
        {
            public static int numberOfEmployees;

            private string name;
            public string Name  //可读可行属性
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            private int counter;
            public int Counter  //这是一个只读属性
            {
                get
                {
                    return counter;
                }
            }

            public Employee()  // constructor
            {
                counter = ++counter + numberOfEmployees;
            }
        }

        class TestEmployee
        {
            static void Main()
            {
                System.Console.Write("Enter number of employees: ");
                Employee.numberOfEmployees = int.Parse(System.Console.ReadLine());

                Employee e1 = new Employee();
                System.Console.Write("Enter the name of the new employee: ");
                e1.Name = System.Console.ReadLine();

                System.Console.WriteLine("The employee information:");
                System.Console.WriteLine("Employee number: {0}", e1.Counter);
                System.Console.WriteLine("Employee name: {0}", e1.Name);
                Console.ReadKey();
            }
        }
    }
}
