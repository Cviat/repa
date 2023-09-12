using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class Car
    {

        [Serializable]
        public struct car
        {
            private int id;
            private string brand_car;
            private int year_release;
            private float engine_volume;
            private int doors;
            public car(int id, string brand, int years, float engine, int door)     
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
                return $"id машины {id} ;марка автомобиля {brand_car}; год выпуска: {year_release}; объем двигателя: {engine_volume}; число дверей: {doors}";
            }
        }
    }
}
