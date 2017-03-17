using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 接口
{
    class 显式接口
    {
        interface IDimensions
        {
            float getLength();                         
            float getWidth();
        }

        class Box : IDimensions
        {
            float lengthInches;
            float widthInches;

            Box(float length, float width)
            {
                lengthInches = length;
                widthInches = width;
            }
            // Explicit interface member implementation: 
            float IDimensions.getLength()               //这里通过显式的方法，注意当有两个接口，且具有同名时候，也可以这样
            {                                           //通过 接口名.方法名 来实现同名不同方法
                return lengthInches;
            }
            // Explicit interface member implementation:
            float IDimensions.getWidth()
            {
                return widthInches;
            }

            static void Main()
            {
                // Declare a class instance box1:
                Box box1 = new Box(30.0f, 20.0f);

                // Declare an interface instance dimensions:
                IDimensions dimensions = (IDimensions)box1;

                //请注意 Main 方法中下列代码行被注释掉，因为它们将产生编译错误。 显式实现的接口成员不能从类实例访问：
                // The following commented lines would produce compilation 
                // errors because they try to access an explicitly implemented
                // interface member from a class instance:                   
                //System.Console.WriteLine("Length: {0}", box1.getLength());    【 ！！显式实现的接口成员不能从类实例访问：】
                //System.Console.WriteLine("Width: {0}", box1.getWidth());

                // Print out the dimensions of the box by calling the methods 
                // from an instance of the interface:
                System.Console.WriteLine("Length: {0}", dimensions.getLength());
                System.Console.WriteLine("Width: {0}", dimensions.getWidth());
            }
        }
        /* Output:
            Length: 30
            Width: 20
        */
    }
}
