using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    public class Student
    {
        int k;
        public int StudId { get; set; }
        public string StudName { get; set; }
        public int StudAge { get; set; }
        public int Grade { get; set; }
        public override string ToString()
        {
            return String.Format("Student ID \t Student Name\t\t Student Age\t\tGrade\n{0} {1,25} {2,25} {3,25}",this.StudId,this.StudName,this.StudAge,this.Grade);
        }
    }
    public class Emp
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public int Deptno { get; set; }
    }
    public class Dept
    {
        public int Deptno { get; set; }
        public string Dname { get; set; }
    }
}
