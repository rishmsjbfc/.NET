using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo1;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SerializeBinary();
            DeserializeBinary();
            //SerializeXML();
            //DeserializeXML();

            //SerializeJSON();
            //DeserializeJSON();
            //example<int> e1 = new example<int>(3);
            //example < string > e2 = new example<string>("London");
            //e1.Show();
            //e2.Show();
            //Console.Read();
        }

        private static void DeserializeJSON()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Customer));
            FileStream fs = new FileStream("custdata.json", FileMode.Open, FileAccess.Read);
            try
            {
                Customer customer = (Customer)serializer.ReadObject(fs);
                Console.WriteLine(customer.Custid);
                Console.WriteLine(customer.Custname);
                Console.WriteLine(customer.City);
            }
            finally
            {
                fs.Flush();
                fs.Close();
                fs.Dispose();
            }
        }

        private static void SerializeJSON()
        {
            FileStream fs = new FileStream("custdata.json", FileMode.Create, FileAccess.Write);
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(Customer));
            try
            {
                Customer c1 = new Customer();
                c1.Custid = 1013;
                c1.Custname = "Rishav";
                c1.City = "Hyderabad";
                dataContractJsonSerializer.WriteObject(fs, c1);
            }
            finally
            {
                fs.Flush();
                fs.Close();
                fs.Dispose();
            }
        }

        private static void DeserializeBinary()
        {
            FileStream fs = new FileStream("custdata.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                Customer c1 = (Customer)formatter.Deserialize(fs);
                Console.WriteLine(c1.Custid);
                Console.WriteLine(c1.Custname);
                Console.WriteLine(c1.Pin);
                Console.WriteLine(c1.City);
                
            }
            finally
            {
                fs.Flush();
                fs.Close();
                fs.Dispose();
            }
        }

        private static void SerializeBinary()
        {
            FileStream fs = new FileStream("custdata.bin", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                Customer c1 = new Customer();
                c1.Custid = 1013;
                c1.Custname = "Rishav";
                c1.City = "Hyderabad";
                c1.Pin = 500032;
                bf.Serialize(fs, c1);
            }
            finally
            {
                fs.Flush();
                fs.Close();
                fs.Dispose();//Dispose the object which is created on the heap
            }
        }

        private static void SerializeXML()
        {
            FileStream fs = new FileStream("custdata.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Customer));
            try
            {
                Customer c1 = new Customer();
                c1.Custid = 1013;
                c1.Custname = "Ishika";
                c1.City = "Bangalore";
                //c1.Pin = 837582;
                xs.Serialize(fs, c1);
            }
            finally
            {
                fs.Flush();
                fs.Close();
                fs.Dispose();//Dispose the object which is created on the heap
            }
        }

        //NOT COMPLETE
        private static void DeserializeXML()
        {
            FileStream fs = new FileStream("custdata.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xe = new XmlSerializer(typeof(Customer));
            try
            {
                Customer c1 = (Customer)xe.Deserialize(fs);
                Console.WriteLine(c1.Custid);
                Console.WriteLine(c1.Custname);
                //Console.WriteLine(c1.Pin);
                Console.WriteLine(c1.City);   
            }
            finally
            {
                fs.Flush();
                fs.Close();
                fs.Dispose();
            }
        }

    }
}
