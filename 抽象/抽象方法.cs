using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象
{
    class 抽象方法
    {
        abstract class ShapesClass                    //定义一个抽象类，因为里面有抽象方法
        {
            abstract public int Area();             //这是一个抽象方法，注意不能有方括号！
        }
        class Square : ShapesClass                //写一个派生类，在这里面重写抽象方法
        {
            int side = 0;

            public Square(int n)                    
            {
                side = n;
            }
            // Area method is required to avoid
            // a compile-time error.                      
            public override int Area()                          //在这里重写，因为抽象方法其实就是隐式的虚方法
            {
                return side * side;
            }

            static void Main()
            {
                Square sq = new Square(12);                   //注意抽象类是不能实例化的，其派生类是可以实例化的
                Console.WriteLine("Area of the square = {0}", sq.Area());
                Console.ReadKey();
            }

            interface I
            {
                void M();
            }
            abstract class C : I
            {
                public abstract void M();
            }
            

        }

        // Output: Area of the square = 144
    }
}
