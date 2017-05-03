using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 属性
{
    class 自动属性
    {    //自动属性----------【编译器将创建仅可以通过该属性的 get 和 set 访问器访问的专用、匿名支持字段。】
        // This class is immutable（不可改变的）. After an object is created,   
        // it cannot be modified from outside the class. It uses a   
        // constructor（构造器） to initialize（初始化） its properties.   
        class Contact
        {
            // Read-only properties.   
            public string Name { get; }              //这里，将创建一个只读的自动属性
            public string Address { get; private set; }   //将 set 取值函数声明为 private。 属性只能在该类型中设置，但它对于使用者是不可变的。

            // Public constructor.   
            public Contact(string contactName, string contactAddress)  //通过上面两种方法，属性只能在该类型构造函数中设置，其他位置都不可变
            {
                Name = contactName;
                Address = contactAddress;
            }
        }

        // This class is immutable. After an object is created,   
        // it cannot be modified from outside the class. It uses a   
        // static method and private constructor to initialize its properties.      
        public class Contact2
        {
            // Read-only properties.   
            public string Name { get; private set; }
            public string Address { get; }

            // Private constructor.   
            private Contact2(string contactName, string contactAddress)
            {
                Name = contactName;
                Address = contactAddress;
            }

            // Public factory method.   
            public static Contact2 CreateContact(string name, string address)   //这是一个静态方法
            {
                return new Contact2(name, address);
            }
        }

        public class Program
        {
            static void Main()
            {
                // Some simple data sources.   
                string[] names = {"Terry Adams","Fadi Fakhouri", "Hanying Feng",
                              "Cesar Garcia", "Debra Garcia"};
                string[] addresses = {"123 Main St.", "345 Cypress Ave.", "678 1st Ave",
                                  "12 108th St.", "89 E. 42nd St."};

                // Simple query to demonstrate object creation in select clause.   
                // Create Contact objects by using a constructor.   
                var query1 = from i in Enumerable.Range(0, 5)
                             select new Contact(names[i], addresses[i]);

                // List elements cannot be modified by client code.   
                var list = query1.ToList();
                foreach (var contact in list)
                {
                    Console.WriteLine("{0}, {1}", contact.Name, contact.Address);
                }

                // Create Contact2 objects by using a static factory method.   
                var query2 = from i in Enumerable.Range(0, 5)
                             select Contact2.CreateContact(names[i], addresses[i]);

                // Console output is identical to query1.   
                var list2 = query2.ToList();

                // List elements cannot be modified by client code.   
                // CS0272:   
                // list2[0].Name = "Eugene Zabokritski";   

                // Keep the console open in debug mode.  
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }

        /* Output:  
            Terry Adams, 123 Main St.  
            Fadi Fakhouri, 345 Cypress Ave.  
            Hanying Feng, 678 1st Ave  
            Cesar Garcia, 12 108th St.  
            Debra Garcia, 89 E. 42nd St.  
        */
    }
}
