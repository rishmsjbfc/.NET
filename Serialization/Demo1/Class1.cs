using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    [Serializable()]
    public class Customer
    {
        public int Custid { get; set; }
        public string Custname { get; set; }
        [NonSerialized]
        int _pin;
        public int Pin { get { return _pin; } set { _pin = value; }}
        public string City { get; set; }
    }
    public class example<T>
    {
        T _i;
        public example(T t)
        {
            _i = t;
        }
        public void Show()
        {
            Console.WriteLine(_i);
        }
    }
}
