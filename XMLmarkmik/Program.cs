using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace XMLmarkmik
{
    class Program
    {
        /// <summary>
        /// Asks user for his choice and has 3 cases to choose from.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Mida soovite teha?\n1.Kirjutada märge.\n2.Lugeda märkmeid.\n3.Kustuta kõik");
                string valik = Console.ReadLine();
                var märkmed = new List<Märge>();

                switch (valik)
                {
                    case "1":
                        WriteXML writeXML = new WriteXML();
                        writeXML.Write();
                        break;
                    case "2":
                        ReadXML readXML = new ReadXML();
                        readXML.Read();
                        break;
                    case "3":
                        File.Delete("märkmed.xml");
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
