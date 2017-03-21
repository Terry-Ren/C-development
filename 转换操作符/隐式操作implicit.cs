using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 转换操作符
{
    class 隐式操作implicit
    {
        struct Digit
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

            public static implicit operator byte(Digit d)  // implicit digit to byte conversion operator
            {
                System.Console.WriteLine("conversion occurred");
                return d.value;  // implicit conversion
            }
        }

        class TestImplicitConversion
        {
            static void Main()
            {
                Digit d = new Digit(3);           
                byte b = d;  // implicit conversion -- no cast needed    【扩大转换】隐式就可以完成
                Console.ReadKey();
            }
        }
        // Output: Conversion occurred.
    }
}
