using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 构造函数1
{
    abstract class Shape
    {
        public const double pi = Math.PI;
        protected double x, y;

        public Shape(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract double Area();
    }

    class Circle : Shape
    {
        public Circle(double radius)
            : base(radius, 0)           //派生类的构造函数都使用其基类的初始值设定项。
        {
        }
        public override double Area()
        {
            return pi * x * x;
        }
    }

    class Cylinder : Circle
    {
        public Cylinder(double radius, double height)
            : base(radius)                         //派生类的构造函数都使用其基类的初始值设定项。x=2.5 y=0
        {
            y = height;   //y=3
        }

        public override double Area()
        {
            return (2 * base.Area()) + (2 * pi * x * y);    //这里的base.Area()返回radius中的19.63
        }
    }

    class TestShapes
    {
        static void Main()
        {
            double radius = 2.5;
            double height = 3.0;

            Circle ring = new Circle(radius);
            Cylinder tube = new Cylinder(radius, height);    //传入（2.5,3.0）

            Console.WriteLine("Area of the circle = {0:F2}", ring.Area());
            Console.WriteLine("Area of the cylinder = {0:F2}", tube.Area());

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    /* Output:
        Area of the circle = 19.63
        Area of the cylinder = 86.39
    */
}
