using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 构造函数
{
    class Program
    {
        public class Taxi
        {
            public bool isInitialized;
            public Taxi()
            {
                isInitialized = true;
            }
        }
        static void Main(string[] args)
        {                              //当 类 或 结构 创建时，其构造函数调用。
            Taxi t = new Taxi();       // 在为新对象分配内存之后，new 运算符立即调用 Taxi 构造函数。
            Console.WriteLine(t.isInitialized);
            Console.ReadKey();
        }
    }
}
