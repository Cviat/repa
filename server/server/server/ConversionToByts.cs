using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    internal class ConversionToByts
    {
        static int CountCar(Cars.car car)      /// метод возращающий длину структуры ,реализован тут для уменьшения связаности кода 
        {
            int i = 0;
            if (car.brand != null) i++;
            if(car.year != 0) i++;
            if(car.engine != 0)i++;
            if(car.dor != 0) i++;

            return i;
        }
        public static byte[] ConvertStructur(Cars.car car)  // метод кодирующий структуру car в байтовую последовательность 
        {
            
            List<byte> bytes = new List<byte>();

            bytes.Add(0x02);
            bytes.Add((byte)CountCar(car));
            if(car.brand != null)
            {
                bytes.Add(0x09);  // начало строки 
                byte[] brandByts = Encoding.ASCII.GetBytes(car.brand);
                bytes.Add((byte)brandByts.Length);    // длина строки
                bytes.AddRange(brandByts);
            }
            if(car.year != 0)
            {
                bytes.Add(0x12); // целое число
                bytes.AddRange(BitConverter.GetBytes(car.year));
            }
            if(car.engine != 0)
            {
                bytes.Add(0x13); // вещественное число
                bytes.AddRange(BitConverter.GetBytes(car.engine));

            }
            if(car.dor != 0)
            {
                bytes.Add(0x12);
                bytes.AddRange(BitConverter.GetBytes((car.dor))); 
            }

            return bytes.ToArray();
        }


    }
}
