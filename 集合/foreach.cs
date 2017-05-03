using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 集合
{


    // Declare the Tokens class. The class implements the IEnumerable interface.
    public class Tokens : IEnumerable
    {
        private string[] elements;

        Tokens(string source, char[] delimiters)
        {
            // The constructor parses the string argument into tokens.
            elements = source.Split(delimiters);        //通过Split方法将字符串分割成相应的数组
        }

        // The IEnumerable interface requires implementation of method GetEnumerator.
        public IEnumerator GetEnumerator()
        {
            return new TokenEnumerator(this);
        }


        // Declare an inner class that implements the IEnumerator interface.
        //在Tokens里面声明出同一个新的类同样继承IEnumerator接口
        private class TokenEnumerator : IEnumerator
        {
            private int position = -1;
            private Tokens t;              

            public TokenEnumerator(Tokens t)
            {
                this.t = t;          //t是一个集合，里面包括上面传递下来的elements数组
            }

            // The IEnumerator interface requires a MoveNext method.
            public bool MoveNext()
            {
                if (position < t.elements.Length - 1)
                {
                    position++;        
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // The IEnumerator interface requires a Reset method.
            public void Reset()
            {
                position = -1;
            }

            // The IEnumerator interface requires a Current method.
            public object Current
            {
                get
                {
                    return t.elements[position];              //将数组中的位置传递给mian函数
                }
            }
        }


        // Test the Tokens class.
        static void Main()
        {
            // Create a Tokens instance.
            Tokens f = new Tokens("This is a sample sentence.", new char[] { ' ', '-' });

            // Display the tokens.
            foreach (string item in f)
            {
                System.Console.WriteLine(item);          //其实际进行访问的是由集合转换后的数组
            }
            Console.ReadKey();
        }
    }
    /* Output:
        This
        is
        a
        sample
        sentence.  
    */
}
