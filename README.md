#  c#的学习
主要内容
=============
1、对多态的理解
---------------
 1. 注意对虚方法和多态的理解
 2. overload和overwride是不同的
 3. 对数组的运用 int[] array1 = new int[5];
 
2、对构造函数的理解
-----------------------
1. 在派生类中我们可以用基类的方法：basc（）
2. 用this关键词也可以调用同一个函数的另一个构造函数

3、抽象方法和抽象类
----------------------
>https://msdn.microsoft.com/zh-cn/library/ms173150.aspx 抽象类、密封类及类成员（C# 编程指南）     
>https://msdn.microsoft.com/zh-cn/library/sf985hc5.aspx abstract（C# 参考）

1. 抽象类的相关内容
2. 抽象方法的相关内容

4、密闭
-----------------
>https://msdn.microsoft.com/zh-cn/library/88c54tsw.aspx sealed（C# 参考）

1. 密闭可以分为对类和对虚方法重写两种情况

5、接口
---------------------
>https://msdn.microsoft.com/zh-cn/library/44a9ty12.aspx  如何：显式实现接口成员（C# 编程指南）      
>https://msdn.microsoft.com/zh-cn/library/ms173156.aspx#BKMK_RelatedSections 接口（C# 编程指南）

1. 对接口基本定义的理解（interface）,接口类似于抽象，但是可以说比抽象更抽象
2. 接口本身不包括方法实现
3. 接口可以分为普通接口和显式接口（接口名称.接口成员名）

6、静态类和静态成员
-------------------------
>https://msdn.microsoft.com/zh-cn/library/k9x6w0hc.aspx 静态构造函数（C# 编程指南）          
>https://msdn.microsoft.com/zh-cn/library/98f28cdx.aspx static（C# 参考）       
>https://msdn.microsoft.com/zh-cn/library/79b3xss3.aspx 静态类和静态类成员（C# 编程指南）

1. 静态可以分为静态类、静态成员两种（静态成员里面还有一个比较特殊的静态构造函数）
2. 静态类中只能有静态成员，且无法实例化是密封的
3. 静态成员可以在非静态类中，只有一个副本，访问不能通过实例访问（只能用类名.静态成员名）
4. 静态构造函数自动运行，无访问修饰符，无参数，只运行一次。

7、转换操作符
----------------------------------
>https://msdn.microsoft.com/zh-cn/library/85w54y0a.aspx 使用转换运算符（C# 编程指南）        
>https://msdn.microsoft.com/zh-cn/library/z5z9kes2.aspx implicit（C# 参考）     
>https://msdn.microsoft.com/zh-cn/library/xhbhezf4.aspx explicit（C# 参考）

1. 转换操作符可以分为implicit（隐式）、explicit（显示）两种方式。
2. 一般而言隐式是扩大转换、显式是缩小转换。
3. 用法为 publice static 转换操作符名称 operater 目标类型 （来源类型 形参）
4. operatpr关键词可以用于重载操作符
5. 用法为piblice static 某一类名（代表在这个类中起作用） operator 运算符	（类型名 变量，类型名 变量）（变量个数由运算符维度决定）
6. 不能重载=、&&、（）、{}、等运算符
7. 传入参数中必须有一个是包容类型的（也就是说必须是原类型声明的参数），为了方便找到重载版本。

8、泛型
-------------------------------------------
1. 泛型是对早期类型与通用基类型object之间进行强制转换的优化，避免了拆箱与装箱。
2. 泛型类参数：     
在泛型类型或方法定义中，类型参数是客户端在实例化泛型类型的变量时指定的特定类型的占位符。  
3. 泛型类参数命名规则   
  *务必使用描述性名称命名泛型类型参数，除非单个字母名称完全可以让人了解它表示的含义，而描述性名称不会有更多的意义。    
 *考虑使用 T 作为具有单个字母类型参数的类型的类型参数名。      
 *务必将“T”作为描述性类型参数名的前缀。
 *考虑在参数名中指示对此类型参数的约束。 

9、属性
---------------------------
>https://msdn.microsoft.com/zh-cn/library/x9fsa0sw.aspx   属性（C# 编程指南）     
>https://msdn.microsoft.com/zh-cn/library/bb383979.aspx     自动实现的属性         
    
1. 属性是一种成员，它提供灵活的机制来读取、写入或计算私有字段的值。 属性可用作公共数据成员，但它们实际上是称为“访问器”的特殊方法。
2. 其方法包括get set。 get 属性访问器用于返回属性值，而 set 访问器用于分配新值。
3. value 关键字用于定义由 set 访问器分配的值。
4. 可以定义接口属性和只读属性。
5. 可以自动实现属性，通过     
 `public string Name { get; set; }`方法可以自动实现。    
6. 可通过两种方法来实现不可变的属性。 可以将 set 取值函数声明为 private。 属性只能在该类型中设置，但它对于使用者是不可变的。   
   也可以仅声明 get 取值函数，使属性除了能在该类型的构造函数中设置，在其他任何位置都不可变。

10、集合
--------------------------------
>http://blog.csdn.net/alisa525/article/details/38656505  哈希表字典      
>https://msdn.microsoft.com/zh-cn/library/6sh2ey19(v=vs.110).aspx   各种集合类的方法

1. 集合相对于数组来说会更加方便在有些情况下
2. 集合包括List、ArrayList、Stack、Queue、HashTable、Dictionary等等。
3. 大部分集合都是可以写成泛型集合，通过指定其中元素的类型，避免了装箱拆箱的问题
4. 数组可以使用foreach方法遍历，同样泛型集合在指定了类型后也是可以用foreach遍历的。

11、事件和委托
-------------------------
>https://msdn.microsoft.com/zh-cn/library/ms173172.aspx 使用委托（C# 编程指南）    

1. 委托是安全封装方法的类型。委托同样需要实例化后才能使用。
2. 委托的声明方法如下：    
   `publice delegate void myDelegate();`    
   修饰符在这里可以省略，同时在委托名中可以传入参数列表（注意参数个数类型应有赋值引用的方法对应。）
3. 委托的引用方法：     
   `myDelegate=p.method;`  
   需要注意的是赋方法引用时候没有圆括号！！
4. 委托调用时候有圆括号，里面可以传入参数。  eg：委托名();
5. Lambda表达式的形式：   
    `myDelegate = () => {};`     
    用法：一种用于创建委托和表达式类型的匿名函数（可以写入作为参数传递和函数返回值的本地函数）
6. Lambda表达式是一种对匿名方法的优化，匿名方法的语法为：    
    `myDelegate = delegate(){  };`
7. 应当注意Lambda表达式的作用范围，其自定义变量会在方法结束后失效，
   其引用同作用域外部变量会内扩展，即在整个作用域内保持有效，直到被垃圾回收。
   