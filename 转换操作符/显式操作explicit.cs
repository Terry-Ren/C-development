using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 转换操作符
{
    class 显式操作explicit
    {
        public struct Digit
        {
            byte value;

            public Digit(byte value)  //constructor
            {
                if (value > 9)
                {
                    throw new System.ArgumentException();
                }
                this.value = value; 
            }
            //注意类型转换时候一定要以 public static +转换操作符+ operator 目标类型 （来源类型 形参）
            public static explicit operator Digit(byte b)  // explicit byte to digit conversion operator
            {
                Digit d = new Digit(b);  // explicit conversion

                System.Console.WriteLine("Conversion occurred.");
                return d;
            }
        }

        class TestExplicitConversion
        {
            static void Main()
            {
                try
                {
                    //因为并非所有字节都可以转换为 Digit，所以该转换是显式的
                    byte b = 3;
                    Digit d = (Digit)b;  // explicit conversion    这里必须要强调类型，属于显示转换
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine("{0} Exception caught.", e);
                }
                Console.ReadLine();
            }
        }
        // Output: Conversion occurred.
    }
}
