using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 属性
{
    class TimePeriod
    {
        private double seconds;
        //属性是一种成员，它提供灵活的机制来读取、写入或计算私有字段的值。 属性可用作公共数据成员，但它们实际上是称为“访问器”的特殊方法。
        public double Hours            //get 属性访问器用于返回属性值，而 set 访问器用于分配新值。 这些访问器可以具有不同的访问级别。
        {
            get { return seconds / 3600; }   //value 关键字用于定义由 set 访问器分配的值。
            set { seconds = value * 3600; }
        }
    }


    class 属性介绍
    {
        static void Main()
        {
            TimePeriod t = new TimePeriod();

            // Assigning the Hours property causes the 'set' accessor to be called.
            t.Hours = 24;

            // Evaluating the Hours property causes the 'get' accessor to be called.
            System.Console.WriteLine("Time in hours: " + t.Hours);
            Console.ReadKey();
        }
    }
    // Output: Time in hours: 24
}
