using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 静态构造函数
{
    public class Bus                               //普通类中是可以包含静态方法的
    {
        // Static variable used by all Bus instances.
        // Represents the time the first bus of the day starts its route.
        protected static readonly DateTime globalStartTime;

        // Property for the number of each bus.
        protected int RouteNumber { get; set; }

        // Static constructor to initialize the static variable.
        // It is invoked before the first instance constructor is run.
        static Bus()                                  //静态构造函数，没有访问修饰符，没有参数，其会在创建实例之前自动调用
        {                                             //非静态构造函数还是会运行
            globalStartTime = DateTime.Now;

            // The following statement produces the first line of output, 
            // and the line occurs only once.
            Console.WriteLine("Static constructor sets global start time to {0}",       //静态构造函数只运行一次
                globalStartTime.ToLongTimeString());
        }

        // Instance constructor.
        public Bus(int routeNum)
        {
            RouteNumber = routeNum;
            Console.WriteLine("Bus #{0} is created.", RouteNumber);
        }

        // Instance method.
        public void Drive()
        {
            TimeSpan elapsedTime = DateTime.Now - globalStartTime;

            // For demonstration purposes we treat milliseconds as minutes to simulate
            // actual bus times. Do not do this in your actual bus schedule program!
            Console.WriteLine("{0} is starting its route {1:N2} minutes after global start time {2}.",
                                    this.RouteNumber,
                                    elapsedTime.TotalMilliseconds,
                                    globalStartTime.ToShortTimeString());
        }
    }

    class TestBus
    {
        static void Main()
        {
            // The creation of this instance activates the static constructor.
            Bus bus1 = new Bus(71);

            // Create a second bus.
            Bus bus2 = new Bus(72);

            // Send bus1 on its way.
            bus1.Drive();

            // Wait for bus2 to warm up.
            System.Threading.Thread.Sleep(25);

            // Send bus2 on its way.
            bus2.Drive();

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    /* Sample output:
        Static constructor sets global start time to 3:57:08 PM.
        Bus #71 is created.
        Bus #72 is created.
        71 is starting its route 6.00 minutes after global start time 3:57 PM.
        72 is starting its route 31.00 minutes after global start time 3:57 PM.      
   */
}
