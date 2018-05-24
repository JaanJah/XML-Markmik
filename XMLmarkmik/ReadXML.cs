using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XMLmarkmik
{
    class ReadXML
    {
        public void Read()
        {
            var märkmed = new List<Märge>();

            var serializer = new XmlSerializer(typeof(List<Märge>));
            using (var reader = XmlReader.Create("märkmed.xml"))
            {
                märkmed = (List<Märge>)serializer.Deserialize(reader);
            }
            foreach (var märge in märkmed)
            {
                Console.WriteLine("Pealkiri: {0}, Sisu: {1}", märge.Pealkiri, märge.Sisu);
            }
            Console.WriteLine();
        }
    }
}
