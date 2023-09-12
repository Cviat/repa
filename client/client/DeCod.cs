using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    internal class DeCod
    {
        public   Car.car ByteToCar(byte[] data)
        {
            Car.car car = new Car.car();
            for (int i = 0;i<data.Length;i++)
            {
                if (data[i] == 0x09)
                {
                    int lenght = (int)data[i + 1];

                    byte[] arrByte = new byte[lenght];
                    Array.Copy(data,i+2, arrByte, 0, lenght);

                    string bufer = Encoding.ASCII.GetString(arrByte);

                    
                    i += lenght + 1;
                    car.brand = bufer;
                }
                if (data[i] == 0x12)
                {
                    byte[] arrByte = new byte[2];
                    Array.Copy(data,i+1,arrByte,0, 2);
                    int intBufer = BitConverter.ToInt16(arrByte,0);
                    if (intBufer >5)car.year = intBufer;
                    else car.dor = intBufer;
                    i += 2;
                }
                if (data[i] == 0x13)
                {
                    byte[] arrByte = new byte[4];
                    Array.Copy(data, i + 1, arrByte, 0, 4);
                    float floatBufer = BitConverter.ToSingle(arrByte,0);
                    car.engine = floatBufer;
                    i += 4;
                }
                
            }



            return car;
        }
        public Car.car[] BytesToCars(byte[] data)
        {
            List<Car.car> cars = new List<Car.car>();
            int id = 0;
            for (int i = 0;i<(data.Length-2);i++)
            {
                if (data[i] ==0x02 && data[i + 2] == 0x09)
                {
                    bool end = false;
                    Car.car car = new Car.car();
                    int border = 0;
                    for (int j = i+1; j < (data.Length-2); j++)
                    {
                        if ((data[j] == 0x02 && data[j + 2] == 0x09))
                        {
                            border = j;
                            break;
                        }
                        if ((data[j] ==0x06)&& (data[j+1] == 0x06)&& (data[j+2] == 0x06)&& (data[j+3] == 0x06))
                        {
                            border = j;
                            end = true;
                        }
                    }

                    
                    byte[] arrByte = new byte[border - i];
                    Array.Copy(data,i, arrByte, 0, border - i);
                    car = ByteToCar(arrByte);
                    id++;
                    car.Id = id;
                    cars.Add(car);
                    i = border-1;
                    if (end) break;

                   


                }
            }
            

            return cars.ToArray();
        }
    }
}
