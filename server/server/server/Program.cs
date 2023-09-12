using server;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

//IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync("место.вашего.домена");
//IPAddress ipAddress = ipHostInfo.AddressList[0];
//IPEndPoint ipEndPoint = new(ipAddress, 22_000); создаю конечную точку , где нахожу ip  по домену , так по идее правильней , но домена у меня нет потому ниже достану его топорней 

IPEndPoint iPEndPoint = new(IPAddress.Parse("127.0.0.1"), 1234);
Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
Console.WriteLine(iPEndPoint.ToString());








Cars.car[] carToClient = Cars.ReadFaile(@"..\..\..\TextFile1.txt");


try
{
    
    serverSocket.Bind(iPEndPoint);
    serverSocket.Listen(10);
    Console.WriteLine("Сервер запущен. Ожидание подключений... ");


    while (true)
    {


        Socket clientSocket = await serverSocket.AcceptAsync();

        var buffer = new byte[16];
        var size = 0;
        var data = new StringBuilder();


        do
        {
            size = clientSocket.Receive(buffer);
            data.Append(Encoding.UTF8.GetString(buffer, 0, size));

        }
        while (clientSocket.Available > 0);
        Console.WriteLine(data);
        var isNumeric = int.TryParse(data.ToString(), out _);
        if (data.ToString() == "ALL")
        {
            List<byte> list = new List<byte>();
            foreach (var item in carToClient)
            {

                byte[] buffer2 = ConversionToByts.ConvertStructur(item);
                list.AddRange(buffer2);
            }
            list.Add(0x06);
            list.Add(0x06);
            list.Add(0x06);
            list.Add(0x06);    // кастыль - конец сообщения
            clientSocket.Send(list.ToArray());
        }
        else if (isNumeric)
        {
            int id = int.Parse(data.ToString());
            if (id < carToClient.Length)
            {
                byte[] buffer2 = ConversionToByts.ConvertStructur(carToClient[id - 1]);
                clientSocket.Send(buffer2);

            }

        }


        clientSocket.Shutdown(SocketShutdown.Both);
        clientSocket.Close();

    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}



