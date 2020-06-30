using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TEst
{
    class Program
    {

        static class s
        {
            static public int startnumber;
            static public object totemstartnumber;
            static public int endnumber;
            static public object totemendnumber;
            static public int count;
            static public object totemcount;
        }


        static void Main(string[] args)
        {
            s.startnumber   = 1_000_000_000;
            s.endnumber     = 1_100_000_000;
            s.totemendnumber = new object();
            s.totemcount = new object();
            s.totemstartnumber = new object();
            s.count = 0;

            DateTime start;
            DateTime finish;

            int nproc = 2;
            start = DateTime.Now;
            Thread[] treads = new Thread[nproc];
            CountdownEvent countdownEvent = new CountdownEvent(nproc + 1);
            for (int ct = 0; ct < nproc; ct++)
            {
                treads[ct] = new Thread(testnums);//Task.Run(() => testnums());
                treads[ct].Start();
            }
            countdownEvent.Signal();
            countdownEvent.Wait();
           // while(treads[0].IsAlive or )
            //Task.WaitAll(treads);
            finish = DateTime.Now;
            Console.WriteLine("{0} , {1}", s.count, finish.Subtract(start));
            Console.ReadLine();
            countdownEvent.Dispose();


            void testnums()
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
                int curvalue;
                while (s.startnumber < s.endnumber)
                {
                    //lock (s.totemstartnumber)
                    //{
                    //    curvalue = s.startnumber++;
                    //}
                    curvalue = Interlocked.Increment(ref s.startnumber);
                    int summ;
                    int lastchar = curvalue%10;
                    switch (lastchar)
                    {
                        case 0:
                            {
                                break;
                            }
                        case 1:
                            {
                                //lock (s.totemcount)
                                //{
                                //    s.count++;
                                //}
                                Interlocked.Increment(ref s.count);
                                break;
                            }
                        default:
                            {
                                summ = 0;
                                //string numstring = curvalue.ToString();
                                ////foreach (char c in numstring)
                                //for (int ic = 0; ic < numstring.Length; ic++)
                                //    summ += (numstring[ic] - '0');
                                int tmp = curvalue;

                                while (curvalue > 0)
                                {
                                    summ += curvalue % 10;
                                    curvalue /= 10;
                                }
                                if ((summ % (lastchar)) != 0)
                                    break;
                                Interlocked.Increment(ref s.count);
                                //lock (s.totemcount)
                                //{
                                //    s.count++;
                                //}
                                break;
                            }
                    }

                }
                countdownEvent.Signal();
            }


        }


    




}
}
