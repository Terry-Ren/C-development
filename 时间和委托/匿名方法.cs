using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 时间和委托
{
    class 匿名方法
    {
        // 声明一个委托.
        delegate void Printer(string s);

        class TestClass
        {
            static void Main()
            {
                //注意现在更多用lambda表达式代替匿名方法
                // 使委托与匿名方法关联
                Printer p = delegate (string j)
                {
                    System.Console.WriteLine(j);
                };

                // 将参数传入匿名方法
                p("The delegate using the anonymous method is called.");

                // 使委托与命名方法 (DoWork) 关联.
                p = new Printer(TestClass.DoWork);

                // Results from the old style delegate call.
                p("The delegate using the named method is called.");
                Console.ReadKey();
            }

            // The method associated with the named delegate.
            static void DoWork(string k)
            {
                System.Console.WriteLine(k);
            }
        }
        /* Output:
            The delegate using the anonymous method is called.
            The delegate using the named method is called.
        */

    }
}
