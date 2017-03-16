using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 构造函数1
{
    class Program
    {
        class CoOrds
        {
            public int x, y;

            // Default constructor:
            public CoOrds()
            {
                x = 0;
                y = 0;
            }

            // A constructor with two arguments:
            public CoOrds(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            // Override the ToString method:
            public override string ToString()    //重写了ToString()方法
            {                                          
                return (String.Format("({0},{1})", x, y));  //Format()函数，将Format它通过格式操作使任意类型的数据转换成一个字符串。
            }
            /*      这是初始的ToString()方法，默认情况下，对象调用 ToString方法将返回类型全名称，也就是命名空间加类型名全称。
              public virtual string ToString()
            {
                 return this.GetType().FullName.ToString();
                }
           */
        }

        class MainClass
        {
            static void Main()
            {
                CoOrds p1 = new CoOrds();
                CoOrds p2 = new CoOrds(5, 3);

                // Display the results using the overriden ToString method:
                Console.WriteLine("CoOrds #1 at {0}", p1);
                Console.WriteLine("CoOrds #2 at {0}", p2);
                Console.ReadKey();
            }
        }
        /* Output:
         CoOrds #1 at (0,0)
         CoOrds #2 at (5,3)        
        */
        }
    }
