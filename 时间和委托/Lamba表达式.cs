using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 时间和委托
{
    class Lamba表达式
    {
        delegate bool D();
        delegate bool D2(int i);

        class Test
        {
            D del;
            D2 del2;
            public void TestMethod(int input)
            {
                int j = 0;
                // Initialize the delegates with lambda expressions.  
                // Note access to 2 outer variables.  
                // del will be invoked within this method.  
                del = () => { j = 10; return j > input; };    //【注意】这一句是在第35行才运行的

                // del2 will be invoked after TestMethod goes out of scope.  
                del2 = (x) => { return x == j; };  //从main中传入参数在这里与j进行比较

                // Demonstrate value of j:                    
                // The delegate has not been invoked yet.  
                Console.WriteLine("j = {0}", j);        // 输出j=0.  
                bool boolResult = del();               //返回ture或者false，这里j已经被改成了10
                //lambda表达式引用外部变量在生存期内扩展，作用范围持续到被垃圾回收
                //所以下一句j依然保持10

                 
                Console.WriteLine("j = {0}. b = {1}", j, boolResult);  //输出 j = 10 b = True 
            }

            static void Main()
            {
                Test test = new Test();
                test.TestMethod(5);

                // Prove that del2 still has a copy of  
                // local variable j from TestMethod.  
                bool result = test.del2(10);

                // 输出: True  
                Console.WriteLine(result);      

                Console.ReadKey();
            }
        }
    }
}
