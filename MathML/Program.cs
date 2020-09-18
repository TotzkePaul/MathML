using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace MathML
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "math.xml";

            using Stream reader = new FileStream(filename, FileMode.Open);

            XmlSerializer xs = new XmlSerializer(typeof(Operations));            

            Operations operations = xs.Deserialize(reader) as Operations;

            foreach(var operation in operations.Items)
            {
                Console.WriteLine(operation);
            }

            Console.ReadKey();
        }
    }
}
