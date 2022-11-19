using System;
using System.Collections;//Non Generic
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayListMethod();
            //StackMethod();
            //QueueMethod();
            HashTableMethod();
            SortedArrayMethod();


            Console.ReadKey();
        }

        private static void SortedArrayMethod()
        {
            SortedList s = new SortedList();
            s.Add(20, "Hello");
            s.Add(12, "Welcome");
            s.Add(2, "Bye");
            s.Add(3, "World");
            s.Add(1, "See you");
            IDictionaryEnumerator ie1 = s.GetEnumerator();
            while (ie1.MoveNext())
            {
                Console.WriteLine("Key = " + ie1.Key);
                Console.WriteLine("Value = " + ie1.Value);
            }
        }

        private static void HashTableMethod()
        {
            Hashtable h = new Hashtable();
            //Key can not repeat
            h.Add("1", 1);
            h.Add(1, 1);
            h.Add("A", 2);
            h.Add("a", 1);
            //h.Remove("A");
            //h.Clear();
            Console.WriteLine(h.ContainsKey("a"));
            h.ContainsValue(1);
            IDictionaryEnumerator ie = h.GetEnumerator();
            while (ie.MoveNext())
            {
                Console.WriteLine("Key = " + ie.Key);
                Console.WriteLine("Value = " + ie.Value);
                Console.WriteLine("-----------------------");
            }
        }

        private static void QueueMethod()
        {
            Queue q = new Queue();
            q.Enqueue(3322);
            q.Enqueue(2213);
            Console.WriteLine(q.Dequeue());//3322
            Console.WriteLine(q.Peek());//2213
            Console.WriteLine(q.Equals(new Queue(q)));
        }

        private static void StackMethod()
        {
            Stack s = new Stack();//LIFO
            s.Push(33);
            s.Push(333.14f);
            s.Push(22.33d);
            s.Push("Hello");
            s.Push("Welcome");
            s.Push('P');
            Console.WriteLine(s.Pop());//P
            Console.WriteLine(s.Peek());//returns the topmost element on stack
            Stack s1 = new Stack();
            s1.Push(33);
            s1.Push(333.14f);
            s1.Push(22.33d);
            s1.Push("Hello");
            s1.Push("Welcome");
            Stack s2 = s1;
            Console.WriteLine(s.Equals(s1));//One by one comparisonfALSE
            Console.WriteLine(s2.Equals(s1));//True
            Console.WriteLine(s1.Contains(s));//False
        }

        private static void ArrayListMethod()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(34);
            arrayList.Add(32.23f);
            arrayList.Add('A');
            arrayList.Add("Hello");
            arrayList.Add(new DateTime(2020, 02, 03));
            ArrayList a1 = new ArrayList(3);
            a1.Add(4345);
            a1.Add(34.333d);
            a1.Add(true);
            a1.Add(false);
            a1.Add("sfsfsf");
            foreach(var item in arrayList)
            {
                Console.WriteLine(item);
            }
            ArrayList a2 = new ArrayList(a1);
            object[] o1 = new object[a2.Count];
            a2.CopyTo(o1);
            foreach (var item in o1)
            {
                Console.WriteLine(item);
            }
            a2.AddRange(arrayList);
            a2.Insert(0, "Rishav");
            ArrayList ax = new ArrayList();
            ax.Add("Rohit");
            ax.Add("Aditya");
            ax.Add("Manjunadh");
            a2.InsertRange(0, ax);
            a2.RemoveRange(0, 3);
            foreach (var item in a2)
            {
                Console.WriteLine(item);
            }
            bool ans = a2.Contains("Hello");
            if (ans)
            {
                int index = a2.IndexOf("Hello");
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("a2 does not contain Hello");
            }

            ArrayList c1 = new ArrayList();
            c1 = a2.GetRange(0, 4);
        }
    }
    
}
