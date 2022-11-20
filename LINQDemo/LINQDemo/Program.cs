using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    internal class Program
    {
        static int count = 1;
        static void Main(string[] args)
        {
            //ArrayExample();
            ListArrayExapmle();
            List<Emp> emps = new List<Emp>();
            emps.Add(new Emp { Empid = 1,Empname="Rishav",Deptno=10});
            emps.Add(new Emp { Empid = 2, Empname = "Suman",Deptno=20});
            emps.Add(new Emp { Empid = 6, Empname = "Anjali", Deptno = 10 });
            emps.Add(new Emp { Empid = 3, Empname = "Kamal", Deptno = 10 });
            emps.Add(new Emp { Empid = 4, Empname = "Kamalani", Deptno = 20 });
            emps.Add(new Emp { Empid = 5, Empname = "Sunil", Deptno = 20 });

            List<Dept> depts = new List<Dept>();
            depts.Add(new Dept{Deptno = 10,Dname = "Dev"});
            depts.Add(new Dept{Deptno = 20,Dname = "Accounts"});
            depts.Add(new Dept{Deptno = 30,Dname = "HR"});

            var joindata = emps.Join(depts, 
                epdata => epdata.Deptno, 
                deptdata => deptdata.Deptno,
                (employee,department)=>new {
                                    eid = employee.Empid,   
                                    ename=employee.Empname,
                                   dname=department.Dname});
            foreach (var item in joindata)
            {
                Console.WriteLine("Employee Id "+item.eid);
                Console.WriteLine("Employee Name "+item.ename);
                Console.WriteLine("Department Name "+item.dname);
                Console.WriteLine("---------------------------------------------");
            }

            List<Student> students = new List<Student>();
            students.Add(new Student { StudAge = 15, StudId = 1, StudName = "Rishav", Grade = 8 });
            students.Add(new Student { StudAge = 15, StudId = 2, StudName = "Ishika", Grade = 8 });
            students.Add(new Student { StudAge = 13, StudId = 3, StudName = "Kamal", Grade = 7 });
            students.Add(new Student { StudAge = 13, StudId = 4, StudName = "Hassan", Grade = 7 });
            students.Add(new Student { StudId = 5, StudName = "Jack", StudAge = 14, Grade = 9 });
            students.Add(new Student { StudId = 6, StudName = "Sparrow", StudAge = 14, Grade = 9 });


            //ListByOrderBy(students);
            //DefferredAndImmediate(students);

        }

        private static void ListByOrderBy(List<Student> students)
        {
            //This will print the Student Name because we are only selecting the student name
            var n = from s in students
                    where s.StudName.ToLower().StartsWith("k")
                    select s.StudName.ToLower();
            var n1 = from s in students
                     let sname = s.StudName.ToLower()
                     where s.StudName.ToLower().EndsWith("a")
                     select sname;
            //foreach(var item in n1)
            //{
            //    Console.WriteLine(item);
            //}
            var n2 = from s in students
                     group s by s.StudAge;
            foreach (var item in n2)
            {
                Console.WriteLine(item);
            }
            var n3 = students.GroupBy(s => s.StudAge);
            var n4 = from s in students
                     orderby s.StudId
                     group s by s.StudAge;
            var n5 = students.OrderBy(s1 => s1.StudId).GroupBy(s => s.StudAge);
            students.Add(new Student { StudId = 7, StudName = "Akhil", StudAge = 15, Grade = 8 });//Defered execution of order by and group by
            var n6 = students.OrderByDescending(s1 => s1.StudAge).ThenBy(s => s.Grade);
            //foreach (var item in n6)
            //{

            //    //Console.WriteLine("\t\t\tGroup {0}",count++);
            //    //Console.WriteLine("Number of students with the age {0} and grade {1} = {2}  ",item.StudAge,item.);
            //    //foreach (var s1 in item)
            //    //{
            //    //    Console.WriteLine(s1);
            //    //}
            //    Console.WriteLine("------------------------------------------------------------------");
            //}
            foreach (var item in n6)
            {
                Console.WriteLine(item);
            }
        }

        private static void DefferredAndImmediate(List<Student> students)
        {
            
            var d1 = students.Where(s => s.StudAge >= 13 && s.StudAge <= 19);
            var data = (from s in students where s.StudAge >= 14 && s.StudAge <= 19 select s).ToList();
            foreach (var item in d1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------------------------------------------------");
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
            students.Add(new Student { StudId = 6, StudName = "Jack", StudAge = 18 });
            
        }

        private static void ListArrayExapmle()
        {
            List<int> intList = new List<int>();
            intList.Add(10);
            intList.Add(20);
            intList.Add(30);
            intList.Add(40);
            intList.Add(61);
            //Sum is 161
            //var result1 = from a in intList where a%2!=0 select a;
            //var result1 = intList.Where(a => a % 2 != 0);
            var result1 = intList.Where(a => a % 2 != 0).ToArray();//Query is executed in this line only if you write .ToArray()
            //intList.Add(45);//No use of writing this when you write .toArray() coz the query has been executed
            var result2 = intList.Where(a => a % 2 != 0).Count();
            //intList.Add(45);//will not reflect in result2
            Console.WriteLine("COUNT");
            Console.WriteLine(result2);
            Console.WriteLine("------------------------");
            Console.WriteLine("SUM");
            var result3 = intList.Sum();
            Console.WriteLine(result3);
            Console.WriteLine("------------------------");
            Console.WriteLine("ORDER BY");
            var result4 = intList.Where(a => a % 2 != 0).OrderBy(a => a);
            intList.Add(45);
            foreach (var item in result4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------");

            Console.WriteLine(result3);
            Console.WriteLine("------------------------");
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------");
            IEnumerable<int> result = from a in intList select a;
            //result.Append(100);//It will not be executed
            intList.Add(100);
            result = intList.Append(200);// Since append creates a new sequence

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            intList.Add(1000);//Will not add
        }

        private static void ArrayExample()
        {
            //List<int> a2 = List<int>();
            int[] a2 = new int[] { 10, 20, 30 };
            int[] arr = new int[9] { 2, 4, 6, 1, 3, 9, 0, 0, 0 };
            //a2.CopyTo(arr,0);//Early Binding//Eager Execution
            Array.Copy(a2, 0, arr, 6, 3);//Early Binding//Eager Execution
            var d = from a in arr select a;
            var e = from b in arr where b % 2 != 0 select b;//IEnumerable<int> is return type
            //a2.CopyTo(arr,0);//Late Binding//Lazy Execution
            Array.Copy(a2, 0, arr, 6, 3);//Late Binding//Lazy Execution
            foreach (var item in d)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------");
            foreach (var item in e)
            {
                Console.WriteLine(item);
            }
        }
    }
}
