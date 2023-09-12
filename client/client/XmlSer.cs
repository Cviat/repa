using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace client
{
    internal class XmlSer
    {
        public  void SerializeToXml<T>(T data, string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (TextWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, data);
                }

                Console.WriteLine("Данные успешно сохранены в XML.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сериализации в XML: " + ex.Message);
            }
        }
    }
}

