using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethodAndDelegates
{
    public class MyClass
    {
        public delegate void CallBack(int i);

        public void Longrunning(CallBack obj)
        {
            Console.WriteLine("----------Delecate called----------");

            for (int i = 0; i < 10; i++)
            {
                //delegte 의 Event가 일어날때 마다 callback 함수를 call한다. 
                obj(i);
                Console.WriteLine("count {0}", i);
            }
        }
    }
}
