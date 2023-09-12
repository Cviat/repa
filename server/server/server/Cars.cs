using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    internal class Cars
    {
        public struct car
        {
            private int id;
            private string brand_car;
            private int year_release ;
            private float engine_volume ;
            private int doors ;
            public car(int id, string brand, int years, float engine, int door)     //конструктор пока не нужен , но пусть будет 
            {
                this.id = id;
                this.brand_car = brand;
                this.year_release = years;            
                this.engine_volume = engine;
                this.doors = door;
            }

            public int Id
            {
                get => id;
                set => id = value;
            }

            public string brand
            {
                get => brand_car;
                set => brand_car = value;
            }
            public int year
            {
                get => year_release;
                set => year_release = value;
            }
            public float engine
            {
                get => engine_volume; 
                set => engine_volume = value;
            }
            public int dor
            {
                get => doors;
                set => doors = value;
            }

            public override string ToString()
            {
                return $"{id};{brand_car};{year_release};{engine_volume};{doors}";
            }
        }
    public static car[] ReadFaile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            car[] cars = new car[lines.Length];
            int i = 0;
            foreach(string line in lines)
            {
                string[] carFields = line.Split(new[] { ';' });
                cars[i].Id = i + 1;                                   // предпологается что записи в файле с машинами не пронумерованны
                if (carFields[0].Length != 0) cars[i].brand = carFields[0];
                if (carFields[1].Length != 0) cars[i].year = Convert.ToInt32(carFields[1]);
                if (carFields[2].Length != 0) cars[i].engine = float.Parse(carFields[2]);
                if (carFields[3].Length!=0)cars[i].dor = Convert.ToInt32(carFields[3]);
                i++;

            }
            return cars;

        }


    }
}
