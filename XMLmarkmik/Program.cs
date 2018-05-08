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
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Mida soovite teha?\n1.Kirjutada märge.\n2.Lugeda märkmeid.");
                string valik = Console.ReadLine();
                var märkmed = new List<Märge>();

                switch (valik)
                {
                    case "1":
                        Console.WriteLine("Sisestage märke pealkiri: ");
                        string pealkiri = Console.ReadLine();
                        Console.WriteLine("Sisestage märke sisu: ");
                        string sisu = Console.ReadLine();
                        if (!File.Exists("märkmed.xml"))
                        {
                            var märge = new Märge() { Pealkiri = pealkiri, Sisu = sisu };
                            märkmed.Add(märge);
                            var serializer1 = new XmlSerializer(märkmed.GetType());
                            using (var writer = XmlWriter.Create("märkmed.xml"))
                            {
                                serializer1.Serialize(writer, märkmed);
                            }
                        }
                        else
                        {
                            var serializer2 = new XmlSerializer(typeof(List<Märge>));
                            using (var reader = XmlReader.Create("märkmed.xml"))
                            {
                                märkmed = (List<Märge>)serializer2.Deserialize(reader);
                            }
                            var uusmärge = new Märge() { Pealkiri = pealkiri, Sisu = sisu };
                            märkmed.Add(uusmärge);

                            using (var writer = XmlWriter.Create("märkmed.xml"))
                            {
                                serializer2.Serialize(writer, märkmed);
                            }
                        }
                        break;
                    case "2":
                        var serializer = new XmlSerializer(typeof(List<Märge>));
                        using (var reader = XmlReader.Create("märkmed.xml"))
                        {
                            märkmed = (List<Märge>)serializer.Deserialize(reader);
                        }
                        foreach (var märge in märkmed)
                        {
                            Console.WriteLine("Pealkiri: {0}, Sisu: {1}", märge.Pealkiri, märge.Sisu);
                        }
                        Console.ReadLine();
                        break;

                }
            }
        }
    }
}
