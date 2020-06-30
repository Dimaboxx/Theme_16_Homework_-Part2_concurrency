using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Theme_16_HomeWork_Part2.Ext;

namespace Theme_16_HomeWork_Part2
{
    class Program
    {
        class paramfortask
        {
            public int Svalue {get; set;}
            public int Fvalue {get; set;}
        }




        static void Main(string[] args)
        {
            int startvalue = 1_000_000_000;
            int finashvalue = 2_000_000_000;
            int summ = new int();
            DateTime start;
            DateTime finish;

            int nproc = 4;
            int delta = (finashvalue - startvalue) / nproc;
            Task<int>[] tasks = new Task<int>[nproc];
            start = DateTime.Now;
            for (int ct = 0; ct < nproc; ct++)
            {
                paramfortask z = new paramfortask
                {
                    Svalue = (startvalue + ct * delta),
                    Fvalue = (startvalue + (ct + 1) * delta)
                };
                //Console.WriteLine($"{z.Svalue} {z.Fvalue}");
                Func< int >  func = () => {
                    Console.WriteLine($"{z.Svalue} {z.Fvalue} {Thread.CurrentThread.ManagedThreadId}");

                    int fstartvalue = z.Svalue;
                    int ffinishvalue = z.Fvalue;

                    int fcount = 0;
                    int fsumm;
                    int fnumtmp;
                    int flastchar;

                    for (int i = fstartvalue; i < ffinishvalue; i++)
                    {
                        flastchar = i % 10;
                        //Console.WriteLine($"{i,10} : {lastchar} | {i.test()} ");
                        switch (flastchar)
                        {
                            case 0:
                                {
                                    continue;
                                    break;
                                }
                            case 1:
                                {
                                    fcount++;
                                    continue;
                                    break;
                                }
                            default:
                                {
                                    fsumm = 0;
                                    fnumtmp = i;
                                    //foreach (char c in numstring)
                                    while (fnumtmp > 0)
                                    {
                                        fsumm += (fnumtmp % 10);
                                        fnumtmp /= 10;
                                    }
                                    if ((fsumm % flastchar) != 0)
                                        continue;
                                    fcount++;
                                    break;
                                }
                        }

                    }
                    Console.WriteLine($"{fcount} {Thread.CurrentThread.ManagedThreadId}");
                    return fcount;
                };
                tasks[ct] = new Task<int>(func);

            }

            foreach(var t in tasks) { t.Start(); }
            Task.WaitAll(tasks);
            summ = 0;
            foreach(var t in tasks)
            {
                summ += t.Result;
            }
            finish = DateTime.Now;
            Console.WriteLine("{0} , {1}", summ, finish.Subtract(start));
            //static async Task<int> testnums(paramfortask z)
            //static int testnums(paramfortask z)
            //{
            //    Console.WriteLine($"{z.Svalue} {z.Fvalue} {Thread.CurrentThread.ManagedThreadId}");

            //    int startvalue = z.Svalue;
            //    int finishvalue = z.Fvalue;

            //    int count = 0;
            //    int summ;
            //    int numtmp;
            //    int lastchar;

            //    for (int i = startvalue; i < finishvalue; i++)
            //    {
            //        lastchar = i % 10;
            //        //Console.WriteLine($"{i,10} : {lastchar} | {i.test()} ");
            //        switch (lastchar)
            //        {
            //            case 0:
            //                {
            //                    continue;
            //                    break;
            //                }
            //            case 1:
            //                {
            //                    count++;
            //                    continue;
            //                    break;
            //                }
            //            default:
            //                {
            //                    summ = 0;
            //                    numtmp = i;
            //                    //foreach (char c in numstring)
            //                    while (numtmp > 0)
            //                    {
            //                        summ += (numtmp % 10);
            //                        numtmp /= 10;
            //                    }
            //                    if ((summ % lastchar) != 0)
            //                        continue;
            //                    count++;
            //                    break;
            //                }
            //        }

            //    }
            //    Console.WriteLine($"{count} {Thread.CurrentThread.ManagedThreadId}");
            //    return count;
            //}
            //start = DateTime.Now;
            //count = 0;
            //for (int i = startvalue; i < finashvalue; i++)
            //    count += i.test3();
            //finish = DateTime.Now;
            //Console.WriteLine($"test 3 {count} {finish.Subtract(start)} ");

            //count = 0;

            //start = DateTime.Now;
            //for (int i = startvalue; i < finashvalue; i++)
            //{
            //     numstring = i.ToString();
            //    char lastchar = numstring.LastOrDefault();
            //    switch (lastchar)
            //    {
            //        case '0':
            //            {
            //                continue;
            //                break;
            //            }
            //        case '1':
            //            {
            //                count++;
            //                continue;
            //                break;
            //            }
            //        default:
            //            {
            //                summ = 0;
            //                //foreach (char c in numstring)
            //                for (int ic = 0; ic < numstring.Length; ic++)
            //                    summ += (numstring[ic] - '0');
            //                if ((summ % (lastchar - '0')) != 0)
            //                    continue;
            //                count++;
            //                break;
            //            }
            //    }

            //}
            //finish = DateTime.Now;
            //Console.WriteLine($"inline {count} {finish.Subtract(start)} ");
            //start = DateTime.Now;
            //count = 0;
            //for (int i = startvalue; i < finashvalue; i++)
            //    count += i.test();
            //finish = DateTime.Now;
            //Console.WriteLine($"test   {count} {finish.Subtract(start)} ");
            //start = DateTime.Now;
            //count = 0;
            //for (int i = startvalue; i < finashvalue; i++)
            //    count += i.test2();
            //finish = DateTime.Now;
            //Console.WriteLine($"test 2 {count} {finish.Subtract(start)} ");

            //count = 0;

            //start = DateTime.Now;
            //for (int i = startvalue; i < finashvalue; i++)
            //{
            //    string numstring = i.ToString();
            //    char lastchar = numstring.LastOrDefault();
            //    if (lastchar != '0')
            //    {
            //        if (lastchar == '1')
            //        {
            //            count++;
            //            continue;
            //        }
            //        summ = 0;
            //        //foreach (char c in numstring)
            //        for (int ic = 0; ic < numstring.Length; ic++)
            //            summ += (numstring[ic] - '0');
            //        if ((summ % (lastchar - '0')) != 0)
            //            continue;
            //        count++;
            //    }

            //    continue;
            //}
            //finish = DateTime.Now;
            //Console.WriteLine($"inlineif {count} {finish.Subtract(start)} ");
            Console.ReadLine();




            //int testnum(int n)
            //{

            //    n.ToString().
            //    return 0;
            //}
        }
    }
}
