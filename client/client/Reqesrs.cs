using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static client.Car;

namespace client
{
    internal class Reqesrs
    {
        public List<Car.car> listCar = new List<Car.car>();
        static IPEndPoint iPEndPoint = new(IPAddress.Parse("127.0.0.1"), 1234);
        XmlSer a = new XmlSer();
        


        static string filePath = "@\"..\\..\\..\\XMLCar.xml";
       
        public void GetAllCars()
        {
            try
            {
                

                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                clientSocket.Connect(iPEndPoint);

                clientSocket.Send(Encoding.ASCII.GetBytes("ALL"));


                byte[] buffer = new byte[1024];

                var size = 0;
                DeCod d = new DeCod();
                do
                {
                   
                    size = clientSocket.Receive(buffer);

                }
                while (clientSocket.Available > 0);
                listCar.AddRange(d.BytesToCars(buffer));
               

                for(int i = 0; i < listCar.Count; i++)
                {
                    
                }
                foreach (var car in listCar)
                {
                    
                    Console.WriteLine(car.ToString());
                }
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
               
                a.SerializeToXml(listCar, filePath);
               
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Ошибка при отправке данных: {ex.Message}");
            }

        }


        public void GetCarsToId()
        {
            try
            {
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(iPEndPoint);
                Console.WriteLine("Введите id нужной вам манышы");


                string id = Console.ReadLine();
                if (int.TryParse(id, out int num))
                {
                    byte[] buffer = new byte[32];
                    DeCod d = new DeCod();
                    Car.car carByfer = new Car.car();
                    clientSocket.Send(Encoding.ASCII.GetBytes(id));
                    clientSocket.Receive(buffer);
                    carByfer = d.ByteToCar(buffer);
                    carByfer.Id = num;
                    Console.WriteLine(carByfer.ToString());

                    a.SerializeToXml(carByfer, filePath);
                }

                else
                {
                    Console.WriteLine("Некоректный запрос");
                    clientSocket.Close();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Ошибка при отправке данных: {ex.Message}");
            }

        }
    }
}
