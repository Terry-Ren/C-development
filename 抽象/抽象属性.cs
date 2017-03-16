using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象
{
    class 抽象属性
    {
        abstract class BaseClass   // Abstract class    //定义一个抽象类，因为里面有抽象方
        {
            protected int _x = 100;
            protected int _y = 150;
            public abstract void AbstractMethod();    //这是一个抽象方法，注意不能有方括号！
            public abstract int X { get; }                 //定义抽象属性
            public abstract int Y { get; }
        }

        class DerivedClass : BaseClass                          //写一个派生类，在这里面重写抽象方法
        {
            public override void AbstractMethod()                 //在这里重写，因为抽象方法其实就是隐式的虚方法
            {
                _x++;
                _y++;
            }

            public override int X   // overriding property
            {
                get
                {
                    return _x + 10;
                }
            }

            public override int Y   // overriding property
            {
                get
                {
                    return _y + 10;
                }
            }

            static void Main()
            {
                DerivedClass o = new DerivedClass();                 //注意抽象类是不能实例化的，其派生类是可以实例化的
                o.AbstractMethod();
                Console.WriteLine("x = {0}, y = {1}", o.X, o.Y);
                Console.ReadKey();
            }
        }
        // Output: x = 111, y = 161

    }
}
