using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 转换操作符
{
    class 重载运算符
    {
        class Fraction
        {
            int num, den;
            public Fraction(int num, int den)
            {
                this.num = num;
                this.den = den;
            }

            // overload operator +
            public static Fraction operator +(Fraction a, Fraction b)  //重载+运算符
            {
                return new Fraction(a.num * b.den + b.num * a.den,
                   a.den * b.den);
            }

            // overload operator *
            public static Fraction operator *(Fraction a, Fraction b) //重载*运算符
            {
                return new Fraction(a.num * b.num, a.den * b.den);
            }

            // user-defined conversion from Fraction to double        
            public static implicit operator double(Fraction f)       //重载double运算符，通过显式的方法
            {
                return (double)f.num / f.den;
            }
        }

        class Test
        {
            static void Main()
            {
                Fraction a = new Fraction(1, 2);
                Fraction b = new Fraction(3, 7);
                Fraction c = new Fraction(2, 3);
                Console.WriteLine((double)(a * b + c));
                Console.ReadKey();
            }
        }
        /*
        Output
        0.880952380952381
        */



    }
}
