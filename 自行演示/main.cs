using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public class Pet
    {
        public string _name;
        public int Age;
        public void printfName()
        {
            Console.WriteLine("hello, " + _name);
        }
        public virtual void Speaking()                    //构建一个虚方法
        {
            Console.WriteLine(_name + "动物会不同的叫。");
        }
        public void running()
        {
            Console.WriteLine(_name + "跑来跑去");
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
            Console.WriteLine("你好" + _name );
        }
        public override void Speaking()
        {
            Console.WriteLine(_name + "汪汪的叫");           //*重写* 重写该方法，与new不同，new是隐藏，nwe下基类不会改变
        }
    }

    /*-------------- 对Dog类进行优化,派生类中用构造函数--------------*/
    public class Dog1 : Pet              
    {
        public Dog1(string name)          //构造函数，是其更加简便
        {
            _name = name;
        }
        public new void printfName()     //*隐藏类型* 通过new关键词进行屏蔽，new不是必须但应该加上。屏蔽注意类型和函数签名都应该相同
        {
            Console.WriteLine("你好" + _name);
        }
        public override void Speaking()
        {
            Console.WriteLine(_name + "汪汪的叫");           //*重写* 重写该方法，与new不同，new是隐藏，nwe下基类不会改变
        }
    }
    /*-------------- 与Dog1 : Pet 派生类进行对比--------------*/
    public class Cat1 : Pet               
    {
        public Cat1(string name)          //构造函数，是其更加简便
        {
            _name = name;
        }
        public new void printfName()     //*隐藏类型* 通过new关键词进行屏蔽，new不是必须但应该加上。屏蔽注意类型和函数签名都应该相同
        {
            Console.WriteLine("你好" + _name);
        }
        public override void Speaking()
        {
            Console.WriteLine(_name + "喵喵的叫");           //*重写* 重写该方法，与new不同，new是隐藏，nwe下基类不会改变
        }
    }
    /*--------------这是一个用了基类构造函数的派生类，并密闭了重写方法、同时采用了显示转换的方法--------------*/
    public class Dog2 : Pet1
    {
        public Dog2(string adc) : base(adc)              //注意这个冒号最好能空一格
        { }
        public new void printfName()     //其他和上面都一样，这里的_Name变量是基类中构造函数定义的
        {
            Console.WriteLine("你好" + _Name);
        }
        public sealed override void Speaking()              //这里密闭了这个方法在继承时候就不能更改了
        {
            Console.WriteLine(_Name + "汪汪的叫");           //同上！
        }
        int d1 = 1;
        public static implicit operator Cat2(Dog2 dog)      //【隐示转换】注意一定要是公开静态，必须要有operator操作符
        { //公开（public）静态（static）转换方法（implicit/explicit） 目标类型（来源类型 形参）
            return new Cat2(dog._Name);
        }
        public static Dog2 operator ++ (Dog2 dog)        //这里试了一下重载了++操作符
        {                                                //上面的参数多个时，至少有一个需要包容类型的（即使用该类型的变量），剩下的可以随意
            dog.d1 += 2;
            return dog;                                 //返回类型一般为包容类型参数名
        }
        public void num()                              //这里将opera后的d1输出
        {
            Console.WriteLine(d1);
        }

        public void happy<T>(T target)                   //这里定义了一个泛型方法，可以将传入的参数转换为指定的类型
        {
            Console.WriteLine("狗狗对" + target.ToString() + "很开心！");
        }
    }
    /*---------------采用了隐式转换的方法------------*/
    public class Cat2 : Pet1
    {
        public Cat2(string adc) : base(adc)              //注意这个冒号最好能空一格
        { }
        public new void printfName()     //其他和上面都一样，这里的_Name变量是基类中构造函数定义的
        {
            Console.WriteLine("你好" + _Name);
        }
        public sealed override void Speaking()              //这里密闭了这个方法在继承时候就不能更改了
        {
            Console.WriteLine(_Name + "喵喵的叫");           //同上！
        }
        public static explicit operator Dog2(Cat2 cat)    //【显式转换】注意事项同上
        {
            return new Dog2(cat._Name);
        }
    }

    /*-----------继承上面的类，注意这里被密闭的就不可以再次重写了--------------*/
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
    /*---------------声明了一个接口----------------*/
    interface Icatch
    {
        void catchThing();                                    //注意接口中的方法不能有定义
    }
    interface Iclimb
    {
        void climbtree();
    }

    /*-------------写一个类用上面的接口--------------*/
    public class JinMao : Pet1, Icatch,Iclimb
    {
        public JinMao(string name) : base(name)     
        {
        }
        void Iclimb.climbtree()                     //这里显式的实现了接口中的方法
        {
            Console.WriteLine(_Name + "不会上树");
        }
        public void catchThing()                  //这里普通的实现了接口的方法
        {
            Console.WriteLine(_Name + "不会抓猫咪");
        }       
    }
    /*--------------基类，里面用了静态构造函数和静态方法--------------*/
    public class Pet3
    {
        public static int counter;       //静态成员，在开始被初始化，之后多次实例化也不会多次初始化
        static Pet3()                   //这里静态构造函数，不过多少个实例，都只运行一次
        {
            Console.WriteLine("我只运行一次");

        }
        protected string _Name;                    //利用protect定义_name变量
        public Pet3(string name)                   //构造基类构造函数
        {
            _Name = name;
            Console.WriteLine("第{0}个小狗被加了进来",++counter);    //这里静态成员不会因为实例的建立而多次初始化，而是值不断增加
        }
        public  void printfName()     //其他和上面都一样，这里的_Name变量是基类中构造函数定义的
        {
            Console.WriteLine("你好" + _Name);
        }
    }
    /*------------------利用静态类的方法扩展上面的类-----------------------------*/
    public static class except              //这里建立了一个静态类，注意只能有静态成员
    {
        public static void e(this Pet3 d)                //静态方法，第一个参数用 this 类名 对象名 的方式来扩展Pet3类的方法
        { 
            Console.WriteLine("这只狗狗逃跑了！");
        }
    }
    /*---------------------------泛型类----------------------------*/
    public class Cage<T>                                   //创建了一个泛型类
    {
        readonly int size;
        T[] array;                                      //创建一个传入类型参数的数组
        int num;
        public  Cage(int num)                          //为这个泛型类创建一个构造函数
        {
            size = num;
            num = 0;
            array = new T[size];                     //初始化一个类型参数的数组
        }
        
        public void Putin(T pet)                   //将满足类型参数的实例传入数组【通过new 类型参数名（）的方法】
        {
            if (num < size)
            {
                array[num++] = pet;
            }
            else
            {
                Console.WriteLine("笼子已经装满了！");
            }
        }
        public T Takeout()
        {
            if (num != 0)
            {
                return array[--num];                 //利用返回值，将数组中的类型返回，可以在实例中，直接返回给一个变量，使得那个变量变成改类型的
            }
            else
            {
                Console.WriteLine("笼子是空的！");
                return default(T);              //返回默认
            }
        } 
              /*---在泛型类中写了一个被约束了的泛型方法-----*/
        public void  Ishappy<T> (T target) where T : Dog2     //约束不仅可以作用于方法，还可以作用于类
        {
            Console.WriteLine(target.ToString() + "让动物开心了！");
            target.printfName();                             //只有添加了约束，才能挑用传入参数中原有的方法（这里就是Dog2中的printname方法）
        }
            /*------关于泛型方法的代码写在了Dog2类型中-------*/
    }
     public class huamn
    {

    }
         /*-------下面是关于泛型接口的方法---------*/
         public abstract class PetCmd
    {
        public abstract string GetCmd();
    }
    public class SitCmd : PetCmd
    {
        public override string GetCmd()
        {
            return "sit";
        }
    }
    public interface IDogLearn<C> where C: PetCmd
    {
        void Act(C cmd);
    }
    public class Idog : Dog2, IDogLearn<SitCmd>
    {
        public Idog(string adc) : base(adc)
        {
        }
        public void Act(SitCmd cmd)   
        {
            Console.WriteLine(cmd.GetCmd());
        }
    }

    //这个类主要是为了委托用一下
    public class Dog4 : Dog1
    {
        public Dog4(string name) : base(name)
        {
        }

        public void wagTail()
        {
            Console.WriteLine(_name + "摇尾巴");
        }
        
    }

    /*--------------下面是主函数---------------*/
    class program
    {
        public delegate void myDelegate();

        static void Main(string[] args)
        {
            Console.WriteLine("===============调用派生类方法==============");
            Dog dog = new Dog();                 //实例化对象 *调用派生类方法*
            dog._name = "Dog";
            dog.Age = 12;
            dog.printfName();
            dog.Speaking();
            dog.running();
            Console.WriteLine();

            Console.WriteLine("===============采用多态的方法==============");
            Pet dogs = new Dog();            //实例化对象 *采用多态的方法*
            dogs._name = "Dogs";
            dogs.Age = 12;
            dogs.printfName();             //这时候对象装换为Pet对象后，这里new写的就不起作用了（接下一行）
            dogs.Speaking();               //输出的就会使基类的hello，而不是您好，这就是多态
            dogs.running();
            Console.WriteLine();

            Console.WriteLine("===============利用数组批量读入==============");
            Pet[] Pets = new Pet[] { new Dog1("优化了的TOM"), new Cat1("优化了的CAT") };//这里利用数组更加简便，在原函数中有该构造函数的存在
            //注意这里数组的声明格式 int[] 名字 =new int[]，比如这里是pet类创建数组，创建的数组叫做Pets，
            //等号后面 Pet[]{ 这里面是声明的个数组类型}
            for (int i=0; i<Pets.Length;i++)             //利用数字遍历每一个方法
            {
                Pets[i].Speaking();
                Pets[i].printfName();
            }
            Console.WriteLine();

            Console.WriteLine("===============派生类用基类构造函数的实例==============");
            Dog2 dog2 = new Dog2("eminem");            //Dgg2类型是一个用了基类Pet1基类中构造函数的实例
            dog2.printfName();
            dog2.Speaking();
            Console.WriteLine();

            Console.WriteLine("===============抽象函数派生类实现后实例化==============");
            Dog3 dog3 = new Dog3();                   //抽象函数派生类实现后实例化
            dog3.Speaking();
            Console.WriteLine();

            TaiDi dog4 = new TaiDi("豆豆");         
            dog4.printfName();
            dog2.Speaking();

            JinMao dog5 = new JinMao("金毛");
            dog5.printfName();
            dog5.catchThing();
            //dog5.climbtree();               这样会出错因为显式后，就不能用类实例实现方法了，应该用接口实例，如下
            Iclimb cb = (Iclimb)dog5;      //因为接口也是引用类型，但不能直接实例，通过强制转化显式实现的类的实例，来实例一个对象
            cb.climbtree();                //通过对象来调用被写了的接口方法    

            Pet3 dog6 = new Pet3("ren");
            dog6.printfName();
            Pet3 dog7 = new Pet3("tian");
            dog7.printfName();
            dog7.e();                   //由于上面用了静态类加静态方法通过this Pet3的方式加入了e（）这一个方法，所以这里可以直接用

            Console.WriteLine("===============显示隐式转换+重载操作符==============");
            /*Dog2类型定义在102行，Cat2类型在其下面*/
            Dog2 dog8 =new Dog2("互相转换的小动物");    //先定义一个名字叫“互相转换的小动物”的Dog2类型的动物
            dog8.Speaking();
            Cat2 cat2 = dog8;                //将dog8【隐式转换】，转换成（cat2类型）赋值给cat2
            cat2.Speaking();
            Dog2 dog9 = (Dog2)cat2;        //在这里将cat2【显式转换】，强制转换成（dog2类型）赋值给dog9     
            dog9.Speaking();
            dog9++;                       //这里使用了一下重载操作符,将opera中的d1从1加到了3
            dog9.num();
            Console.WriteLine();

            var dogCage = new Cage<Dog2>(1);             //这里创建了一个cage泛型的实例化
            dogCage.Putin(new Dog2("笼子动物1"));       //将dog2类型的实例传入到dogcage中
            dogCage.Putin(new Dog2("笼子动物2"));
            var dog10 = dogCage.Takeout();              //这里将该方法返回值赋值给了dog10
            dog10.printfName();                        //因为dog10得到了泛型中的返回值，所以其类型也是Dog2的，同样也拥有Dog2类中的方法

            dog10.happy<int>(2323);                    //这里用了一个泛型方法
            dog10.happy<huamn>(new huamn());          //同样可以这样传进来一个类

            dogCage.Ishappy<Dog2>(new Dog2("泛型的小动物"));   //这里是运用了泛型约束方法的实例化，所以需要满足约束，即必须是Dog2类型的参数传入

            Idog dog11 = new Idog("泛型接口狗狗");
            dog11.printfName();
            dog11.Act(new SitCmd());
            Console.WriteLine("===============下面是相关集合==============");
            Console.WriteLine();
            Console.WriteLine("===============【1】list<T>类==============");
            List<Dog1> lists = new List<Dog1>();          //声明一个list的泛型类
            lists.Add(new Dog1("list1"));                //这里用了Add（）方法
            lists.Add(new Dog1("list2"));
            for(int i=0;i<lists.Count;i++)               //这里用了count属性
            {
                lists[i].printfName();
            }
            lists.Remove(lists[1]);
            Console.WriteLine("-------------下面是Remove掉一个后的--------------");
            for (int i = 0; i < lists.Count; i++)
            {
                lists[i].printfName();
            }
            Console.WriteLine();
            Console.WriteLine("===============【2】Stack<T>类==============");
            Stack<Dog1> stacks = new Stack<Dog1>();
            stacks.Push(new Dog1("stack1"));
            stacks.Push(new Dog1("stack2"));
            Console.WriteLine("-------------peak查看栈顶但是不弹出--------------");
            var dog12 = stacks.Peek();
            dog12.printfName();
            Console.WriteLine("-------------下面将栈顶的弹出--------------");
            var dog13 = stacks.Pop();
            dog13.printfName();
            Console.WriteLine("-------------peak再次查看栈顶但是不弹出--------------");
            dog12 = stacks.Peek();
            dog12.printfName();
            Console.WriteLine("===============【3】Queue<T>类==============");
            Queue<Dog1> queues = new Queue<Dog1>();
            queues.Enqueue(new Dog1("queue1"));
            queues.Enqueue(new Dog1("queue2"));
            foreach (Dog1 item in queues)          //通过foreach遍历集合中的每一项
            {
                item.printfName();
            }
            Console.WriteLine("-------------插入两个弹出从先插入的弹出--------------");
            var dog14 = queues.Dequeue();
            dog14.printfName();
            Console.WriteLine("===============【3】dictionary<T>类==============");
            Dictionary<string, Dog1> dics = new Dictionary<string, Dog1>();
            dics.Add("labuladuo",new Dog1("doc1"));
            dics.Add("guibin", new Dog1("doc2"));
            foreach (Dog1 item in dics.Values)   //从valus中遍历各项
            {
                item.printfName();
            }
            Console.WriteLine("===============下面是委托的使用==============");
            //委托声明不能放在mian里面，这里放在了mian的上面(也可以放在某一个类里面)
            Dog1 dog15 = new Dog1("委托的狗狗");
            myDelegate mdl = dog15.Speaking;      //注意这里只是赋值方法的引用，没有括号的！
            //myDelegate也是一种类型，所以要先实例化再使用
            mdl();
            Console.WriteLine();
            Cat2 cat3 = new Cat2("委托的猫猫");
            mdl += cat3.Speaking;               //这里通过+=运算符将一个实例中再加入一个方法
            mdl();                              //这时候一次调用就可以调用两个方法


            Console.ReadKey();           //Keep the console open in debug mode.

        }
    }
}
