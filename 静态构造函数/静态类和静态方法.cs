using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 静态构造函数
{
    class 静态类和静态方法
    {
        public static class TemperatureConverter                  //静态类，仅包含静态成员。当然这里也可以不声明为静态类
        {
            // 静态方法和属性不能访问其包含类型中的非静态字段和事件，并且不能访问任何对象的实例变量
            public static double CelsiusToFahrenheit(string temperatureCelsius)
            {
                // Convert argument to double for calculations.
                double celsius = Double.Parse(temperatureCelsius);

                // Convert Celsius to Fahrenheit.
                double fahrenheit = (celsius * 9 / 5) + 32;

                return fahrenheit;
            }

            public static double FahrenheitToCelsius(string temperatureFahrenheit)
            {
                // Convert argument to double for calculations.
                double fahrenheit = Double.Parse(temperatureFahrenheit);

                // Convert Fahrenheit to Celsius.
                double celsius = (fahrenheit - 32) * 5 / 9;

                return celsius;
            }
        }

        class TestTemperatureConverter
        {
            static void Main()
            {
                Console.WriteLine("Please select the convertor direction");
                Console.WriteLine("1. From Celsius to Fahrenheit.");
                Console.WriteLine("2. From Fahrenheit to Celsius.");
                Console.Write(":");

                string selection = Console.ReadLine();
                double F, C = 0;

                switch (selection)
                {
                    case "1":
                        Console.Write("Please enter the Celsius temperature: ");
                        F = TemperatureConverter.CelsiusToFahrenheit(Console.ReadLine());     //静态成员只能通过类名.方法来引用
                        Console.WriteLine("Temperature in Fahrenheit: {0:F2}", F);            //不能实例化对象引用
                        break;

                    case "2":
                        Console.Write("Please enter the Fahrenheit temperature: ");
                        C = TemperatureConverter.FahrenheitToCelsius(Console.ReadLine());
                        Console.WriteLine("Temperature in Celsius: {0:F2}", C);
                        break;

                    default:
                        Console.WriteLine("Please select a convertor.");
                        break;
                }

                // Keep the console window open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
        /* Example Output:
            Please select the convertor direction
            1. From Celsius to Fahrenheit.
            2. From Fahrenheit to Celsius.
            :2
            Please enter the Fahrenheit temperature: 20
            Temperature in Celsius: -6.67
            Press any key to exit.
         */

    }
}
