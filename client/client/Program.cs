using System.Net.Sockets;
using System.Net;
using System.Text;
using System;
using client;

while(true) { 

Reqesrs reqesrs = new Reqesrs();
Console.WriteLine("Выберите действие:");
Console.WriteLine("1. Запросить все автомобили");
Console.WriteLine("2. Запросить автомобиль по номеру записи");
    string input = Console.ReadLine();
    if (input.All(char.IsDigit))
    {
        int choice = int.Parse(input);

        switch (choice)
        {
            case 1:
                reqesrs.GetAllCars();
                break;
            case 2:
                reqesrs.GetCarsToId();

                break;
        }

    }
}








