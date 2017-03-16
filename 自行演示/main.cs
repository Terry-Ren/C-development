using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public class Pet
    {
        public string Name;
        public int Age;
        public void printfName()
        {
            Console.WriteLine("hello, " + Name);
        }
        public virtual void Speaking()                    //构建一个虚方法
        {
            Console.WriteLine(Name + "动物会不同的叫。");
        }
        public void running()
        {
            Console.WriteLine(Name + "跑来跑去");
        }              
    }

    /*--------------在基类中用了构造函数的类型--------------*/
    public class Pet1                               
    {
        public Pet1(string name)                   //构造基类构造函数
        {
            _Name = name;
        }
        protected string _Name;                     //利用protect定义_name变量
        public int Age;
        public void printfName()
        {
            Console.WriteLine("hello, " + _Name);
        }
        public virtual void Speaking()                    //构建一个虚方法
        {
            Console.WriteLine(_Name + "动物会不同的叫。");
        }
        public void running()
        {
            Console.WriteLine(_Name + "跑来跑去");
        }
    }
    /*--------------这是一个用抽象方法写的基类--------------*/
    public abstract class Pet2                          
    {
        public abstract void Speaking();                  //在这里我们用了抽象方法
    }

    /*--------------这里我们用了上面的继承方法--------------*/
    public class Dog:Pet               
    {
         public new void printfName()     //*隐藏类型* 通过new关键词进行屏蔽，new不是必须但应该加上。屏蔽注意类型和函数签名都应该相同
        {
            Console.WriteLine("你好" + Name );
        }
        public override void Speaking()
        {
            Console.WriteLine(Name + "汪汪的叫");           //*重写* 重写该方法，与new不同，new是隐藏，nwe下基类不会改变
        }
    }

    /*-------------- 对Dog类进行优化,派生类中用构造函数--------------*/
    public class Dog1 : Pet              
    {
        public Dog1(string name)          //构造函数，是其更加简便
        {
            Name = name;
        }
        public new void printfName()     //*隐藏类型* 通过new关键词进行屏蔽，new不是必须但应该加上。屏蔽注意类型和函数签名都应该相同
        {
            Console.WriteLine("你好" + Name);
        }
        public override void Speaking()
        {
            Console.WriteLine(Name + "汪汪的叫");           //*重写* 重写该方法，与new不同，new是隐藏，nwe下基类不会改变
        }
    }
    /*-------------- 与Dog1 : Pet 派生类进行对比--------------*/
    public class Cat1 : Pet               
    {
        public Cat1(string name)          //构造函数，是其更加简便
        {
            Name = name;
        }
        public new void printfName()     //*隐藏类型* 通过new关键词进行屏蔽，new不是必须但应该加上。屏蔽注意类型和函数签名都应该相同
        {
            Console.WriteLine("你好" + Name);
        }
        public override void Speaking()
        {
            Console.WriteLine(Name + "喵喵的叫");           //*重写* 重写该方法，与new不同，new是隐藏，nwe下基类不会改变
        }
    }
    /*--------------这是一个用了基类构造函数的派生类，并密闭了重写方法--------------*/
    public class Dog2 : Pet1             
    {
        public Dog2(string adc) :base(adc)              //注意这个冒号最好能空一格
        { }
        public new void printfName()     //其他和上面都一样，这里的_Name变量是基类中构造函数定义的
        {
            Console.WriteLine("你好" + _Name);
        }
        public sealed override void Speaking()              //这里密闭了这个方法在继承时候就不能更改了
        {
            Console.WriteLine(_Name + "汪汪的叫");           //同上！
        }
    }
    public class TaiDi : Dog2
    {
        public TaiDi(string name) : base(name)
        {
        }
      /* public override void Speaking()
        {

        }                这里不能这样重写了，因为speak在其父类中已经被密封*/
    }


    /*--------------这里是一个实现抽象基类方法的派生类--------------*/
    public class Dog3 : Pet2
    {
        public override void Speaking()
        {
            Console.WriteLine("抽象方法在这里实现了！");
        }
    }
    class program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();                 //实例化对象 *调用派生类方法*
            dog.Name = "Dog";
            dog.Age = 12;
            dog.printfName();
            dog.Speaking();
            dog.running();


            Pet dogs = new Dog();                //实例化对象 *采用多态的方法*
            dogs.Name = "Dogs";
            dogs.Age = 12;
            dogs.printfName();             //这时候对象装换为Pet对象后，这里new写的就不起作用了（接下一行）
            dogs.Speaking();               //输出的就会使基类的hello，而不是您好，这就是多态
            dogs.running();


            Pet[] Pets = new Pet[] { new Dog1("优化了的TOM"), new Cat1("优化了的CAT") };//这里利用数组更加简便，在原函数中有该构造函数的存在
            //注意这里数组的声明格式 int[] 名字 =new int[]，比如这里是pet类创建数组，创建的数组叫做Pets，
            //等号后面 Pet[]{ 这里面是声明的个数组类型}
            for (int i=0; i<Pets.Length;i++)             //利用数字遍历每一个方法
            {
                Pets[i].Speaking();
                Pets[i].printfName();
            }

            Dog2 dog2 = new Dog2("eminem");            //Dgg2类型是一个用了基类Pet1基类中构造函数的实例
            dog2.printfName();
            dog2.Speaking();

            Dog3 dog3 = new Dog3();                   //抽象函数派生类实现后实例化
            dog3.Speaking();

            TaiDi dog4 = new TaiDi("豆豆");         
            dog4.printfName();
            dog2.Speaking();

            Console.ReadKey();           //Keep the console open in debug mode.
        }
    }
}
