using System;
using System.Diagnostics;

namespace AnonymousMethodAndDelegates
{
    class Program
    {
        delegate int PointtoAddFunction(int num1, int num2);

       
        static void Main(string[] args)
        {
            //1. Degate  , Callback for data commucation
            MyClass obj = new MyClass();
            obj.Longrunning(Callback);

            //2. Running Delegate and Anonymout method performance Test
            //AnonymousUsage();
        }

        static void Callback(int i)
        {
            Console.WriteLine("Callback function called");
            Console.WriteLine(i);
        }

        private static void AnonymousUsage()
        {
            Stopwatch objwatch = new Stopwatch();


            Console.WriteLine("Nomal Add run!");
            for (int j = 0; j < 10; j++)
            {
                objwatch.Reset();
                objwatch.Start();
                for (int i = 0; i < 1000; i++)
                {
                    int temp = Add(2, 2);
                }

                objwatch.Stop();
                Console.WriteLine(objwatch.ElapsedTicks.ToString());
            }


            Console.WriteLine("Nomal Delegate run!");
            for (int j = 0; j < 10; j++)
            {
                objwatch.Reset();
                objwatch.Start();
                for (int i = 0; i < 1000; i++)
                {
                    PointtoAddFunction pobjAdd = Add;
                    int temp = pobjAdd(2, 2);
                    //Console.WriteLine(pobjAdd.Invoke(2, 2).ToString());
                    //Console.ReadLine();
                }

                objwatch.Stop();
                Console.WriteLine(objwatch.ElapsedTicks.ToString());
            }


            Console.WriteLine("Anonymous Delegate run!");
            for (int j = 0; j < 10; j++)
            {
                objwatch.Reset();
                objwatch.Start();

                for (int i = 0; i < 1000; i++)
                {


                    //anonymous method
                    PointtoAddFunction pobAdd2 = delegate (int num1, int num2)
                    {
                        return num1 + num2;
                    };
                    int temp = pobAdd2(2, 2);
                    //Console.WriteLine(pobAdd2.Invoke(2, 2).ToString());
                    //Console.ReadLine();
                }

                objwatch.Stop();
                Console.WriteLine(objwatch.ElapsedTicks.ToString());
            }
        }
        static int Add(int num1, int num2)
        {
            return num1 + num2;
        }
        //Nomal Add run!
        //299
        //20
        //21
        //21
        //22
        //21
        //22
        //20
        //22
        //14
        //Nomal Delegate run!
        //82
        //77
        //86
        //68
        //62
        //72
        //129
        //121
        //68
        //61
        //Anonymous Delegate run!
        //265
        //20
        //20
        //20
        //20
        //20
        //20
        //30
        //31
        //30
    }
}
