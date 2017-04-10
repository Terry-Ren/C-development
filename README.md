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
7. 传入参数中必须有一个是包容类型的（也就是说必须是原类型声明的参数），为了方便找到重载版本