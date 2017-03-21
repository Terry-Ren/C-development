using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 转换操作符
{
    class 第二个显式的
    {

        class Celsius
        {
            public Celsius(float temp)
            {
                degrees = temp;
            }
            public static explicit operator Fahrenheit(Celsius c)        //【强制转换】再次强制转换为华氏度
            {
                return new Fahrenheit((9.0f / 5.0f) * c.degrees + 32);
            }
            public float Degrees
            {
                get { return degrees; }
            }
            private float degrees;
        }

        class Fahrenheit
        {
            public Fahrenheit(float temp)
            {
                degrees = temp;
            }
            // Must be defined inside a class called Fahrenheit:
            public static explicit operator Celsius(Fahrenheit fahr)      //【强制转换】传入的华氏度的格式转换为摄氏度
            {
                return new Celsius((5.0f / 9.0f) * (fahr.degrees - 32));
            }
            public float Degrees
            {
                get { return degrees; }
            }
            private float degrees;
        }

        class MainClass
        {
            static void Main()
            {
                Fahrenheit fahr = new Fahrenheit(100.0f);
                Console.Write("{0} Fahrenheit", fahr.Degrees);    //这里是先是华氏度
                Celsius c = (Celsius)fahr;                        //这里强制转化为摄氏度

                Console.Write(" = {0} Celsius", c.Degrees);       //输出强制转换后的摄氏度
                Fahrenheit fahr2 = (Fahrenheit)c;                 //再转换为华氏度
                Console.WriteLine(" = {0} Fahrenheit", fahr2.Degrees);    //输出华氏度
                Console.ReadKey();
            }
        }
        // Output（结果）:
        // 100 Fahrenheit = 37.77778 Celsius = 100 Fahrenheit
    }
}
