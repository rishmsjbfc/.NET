using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char ch = Convert.ToChar('a' | 'b' | 'c');
            Console.WriteLine(ch);
            int a = 100, b = 200;
            SwapNos(a, b);
            Console.WriteLine("{0},{1}", a, b);
            SwapNosRef(ref a,ref b);
            Console.WriteLine("{0},{1}", a, b);
            int addOutput, subtractOutput, MultOutput;
            double DivOutput;
            int t = 20, u = 2;
            DoCalculations(ref t, ref u, out addOutput, out subtractOutput, out MultOutput, out DivOutput);
            Console.WriteLine(addOutput);
            Console.WriteLine(subtractOutput);
            Console.WriteLine(MultOutput);
            Console.WriteLine(DivOutput);
            Console.ReadKey();

        }
        
        static public void DoCalculations(ref int g,ref int h,out int addres,out int subres,out int multres,out double divres)
        {
            addres = g + h;
            subres = g - h;
            multres = g * h;
            divres = g / h;
            SwapNosRef(ref g,ref h);
        }
        static void SwapNos(int no1,int no2)
        {
            no1 = no1 + no2;
            no2 = no1 - no2;
            no1 = no1 - no2;
            Console.WriteLine("The swapped values for number1 and number2 are {0},{1}",no1,no2);
        }
        static void SwapNosRef(ref int no1,ref int no2)
        {
            no1 = no1 + no2;
            no2 = no1 - no2;
            no1 = no1 - no2;
            Console.WriteLine("The swapped values for number1 and number2 are {0},{1}", no1, no2);
        }
    }
}
