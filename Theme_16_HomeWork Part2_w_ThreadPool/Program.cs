using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Theme_16_HomeWork_Part2_w_ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {

            const int StartN = 1_000_000_000;
            const int EndN = 2_000_000_000;
            const int nproc = 4;
            DateTime start;
            DateTime finish;

            int res = 0;

            var doneEvents = new ManualResetEvent[nproc];
            var resArray = new GetNum[nproc];
            start = DateTime.Now;
            Console.WriteLine($"Launching {nproc} tasks...");
            int delta = (EndN - StartN) / nproc;
            for (int i = 0; i < nproc; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                var gn = new GetNum(StartN + i * delta, StartN + (i + 1) * delta, doneEvents[i]);
                resArray[i] = gn;
                ThreadPool.QueueUserWorkItem(gn.ThreadPoolCallback, i);
            }

            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("All calculations are complete.");

            for (int i = 0; i < nproc; i++)
            {
                GetNum gn = resArray[i];
                res += gn.NUM;
                Console.WriteLine($"res ({gn.NUM})");
            }
            finish = DateTime.Now;
            Console.WriteLine("{0} , {1}", res, finish.Subtract(start));
            Console.ReadLine();

        }
    }
        public class GetNum
        {
            private ManualResetEvent _doneEvent;
            private int Nstart;
            private int Nend;


            public GetNum(int startnumber, int endnumber, ManualResetEvent doneEvent)
            {
                Nstart = startnumber;
                Nend = endnumber;
                _doneEvent = doneEvent;
            }
            public int NUM { get; private set; }

            public void ThreadPoolCallback(Object threadContext)
            {
                int threadIndex = (int)threadContext;
                //Console.WriteLine($"Thread {threadIndex} started...");
                NUM = testnums(Nstart,Nend);
                //Console.WriteLine($"Thread {threadIndex} result calculated...");
                _doneEvent.Set();
            }


            //static async Task<int> testnums(paramfortask z)
            static int testnums(int s, int f)
            {
                Console.WriteLine($"{s} {f} {Thread.CurrentThread.ManagedThreadId}");

                int startvalue = s;
                int finishvalue = f;

                int count = 0;
                int summ;
                int numtmp;
                int lastchar;

                for (int i = startvalue; i < finishvalue; i++)
                {
                    lastchar = i % 10;
                    //Console.WriteLine($"{i,10} : {lastchar} | {i.test()} ");
                    switch (lastchar)
                    {
                        case 0:
                            {
                                continue;
                                break;
                            }
                        case 1:
                            {
                                count++;
                                continue;
                                break;
                            }
                        default:
                            {
                                summ = 0;
                                numtmp = i;
                                //foreach (char c in numstring)
                                while (numtmp > 0)
                                {
                                    summ += (numtmp % 10);
                                    numtmp /= 10;
                                }
                                if ((summ % lastchar) != 0)
                                    continue;
                                count++;
                                break;
                            }
                    }

                }
                Console.WriteLine($"{count} {Thread.CurrentThread.ManagedThreadId}");
                return count;
            }
        }

        //    public class Fibonacci
        //{
        //    private ManualResetEvent _doneEvent;

        //    public Fibonacci(int n, ManualResetEvent doneEvent)
        //    {
        //        N = n;
        //        _doneEvent = doneEvent;
        //    }

        //    public int N { get; }

        //    public int FibOfN { get; private set; }

        //    public void ThreadPoolCallback(Object threadContext)
        //    {
        //        int threadIndex = (int)threadContext;
        //        Console.WriteLine($"Thread {threadIndex} started...");
        //        FibOfN = Calculate(N);
        //        Console.WriteLine($"Thread {threadIndex} result calculated...");
        //        _doneEvent.Set();
        //    }

        //    public int Calculate(int n)
        //    {
        //        if (n <= 1)
        //        {
        //            return n;
        //        }
        //        return Calculate(n - 1) + Calculate(n - 2);
        //    }
        //}


    
}
