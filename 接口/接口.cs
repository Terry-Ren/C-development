using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 接口
{
    class 接口
    {
        class Test
        {
            static void Main()
            {
                SampleClass sc = new SampleClass();           
                IControl ctrl = (IControl)sc;                  //因为interface是引用类型，这里可以通过类实例来强制转换做声明
                ISurface srfc = (ISurface)sc;                 //接口不能直接实例化，但是可以通过这种方式达到实例化的效果

                // The following lines all call the same method.
                sc.Paint();
                ctrl.Paint();
                srfc.Paint();
                Console.ReadKey();
            }
        }


        interface IControl                               //声明一个接口，接口不能被直接实例化
        {
            void Paint();                               //注意接口不包括方法实现，两个接口有一个同签名的方法
        }                                               //同时接口不能有任何访问修饰符
        interface ISurface                                
        {
            void Paint();                              //同签名的方法      
        }
        class SampleClass : IControl, ISurface
        {
            // Both ISurface.Paint and IControl.Paint call this method. 
            public void Paint()                         
            {
                Console.WriteLine("Paint method in SampleClass");
            }
        }

        // Output:
        // Paint method in SampleClass
        // Paint method in SampleClass
        // Paint method in SampleClass
    }
}
