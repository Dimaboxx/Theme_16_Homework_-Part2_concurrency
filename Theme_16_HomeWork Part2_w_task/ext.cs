using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme_16_HomeWork_Part2
{
    namespace Ext
    {
        public static class MyExt
        {
                        public static int getcharsumm(this int num)
            {
                int tmp = num;
                int summ = new int();
                while (tmp > 0)
                {
                    summ += tmp%10;
                    tmp /= 10;
                }
                return summ;
            }

            public static int test(this int num)
            {
                int lastchar = num%10;
                if (lastchar != 0)
                {
                    if (lastchar == 1)
                        return 1;

                    int tmp = num;
                    int summ = new int();
                    while (tmp > 0)
                    {
                        summ += tmp % 10;
                        tmp /= 10;
                    }
                    if (summ % lastchar == 0)
                        return 1;
                }
                return 0;
            }



            public static int getcharsummS(this int num)
            {
                string numstring = num.ToString();
                int summ = new int();
                foreach (char c in numstring)
                {
                    summ += c.getzerobase();
                }
                return summ;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="c"></param>
            /// <returns></returns>
            public static int getzerobase(this char c)
            {
                return c - '0';
            }

            public static int test_o(this int num)
            {
                string numstring = num.ToString();
                char lastchar = numstring.LastOrDefault();
                if (lastchar  != '0')
                {


                    int summ = new int();
                    foreach (char c in numstring)
                    {
                        summ += c.getzerobase();
                    }
                    if (summ % lastchar.getzerobase() == 0)
                    return 1;
                }
                return 0;
            }

            public static int test2(this int num)
            {
                string numstring = num.ToString();
                char lastchar = numstring.LastOrDefault();
                if (lastchar != '0')
                {
                    if (lastchar == '1')
                        return 1;

                    int summ = new int();
                    foreach (char c in numstring)
                    {
                        summ += c.getzerobase();
                    }
                    if (summ % lastchar.getzerobase() == 0)
                        return 1;
                }
                return 0;
            }
            public static int test3(this int num)
            {
                string numstring = num.ToString();
                char lastchar = numstring.LastOrDefault();
                if (lastchar != '0')
                {
                    

                    int summ = new int();
                    foreach (char c in numstring)
                    {
                        summ += c.getzerobase();
                    }
                    if (summ % lastchar.getzerobase() == 0)
                        return 1;
                }
               // if (lastchar == '1')
                //    return 1;
                return 0;
            }
        }
    }
}
