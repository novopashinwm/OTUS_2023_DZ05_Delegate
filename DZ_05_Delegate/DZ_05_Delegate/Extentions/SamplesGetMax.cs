using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_05_Delegate.Extentions
{
    public class SamplesGetMax
    {
        public void Demo() 
        {
            var floats = new List<float>( new float[] { 36.6f, 37.1f, 38.5f, 39.2f });
            var names = new List<string>( new string[] { "Alber", "John", "Ivan", "William" } );
            var ints = new List<int> (new int[] { 1234, 1945, 324, 125, 2051} );
            var maxFloat = floats.GetMax(x => x);
            var maxInt = ints.GetMax(x => x);
            var maxStr = names.GetMax(x => x);

            var poets = new List<Poet> 
            {
                new Poet {Name="Aleksandr", FIO = "Pushkin", BirthYear = 1799},
                new Poet {Name="Aleksandr", FIO = "Block", BirthYear = 1880},
                new Poet {Name="Vladimir", FIO = "Majakovskij", BirthYear = 1893},
                new Poet {Name="Fedor", FIO = "Tutchev", BirthYear = 1803},
                new Poet {Name="Sasha", FIO ="Chernij", BirthYear = 1880 }
            };

            var maxPoetByYear = poets.GetMax(x => x.BirthYear);
            var maxPoetByName = poets.GetMax(x => x.Name);
            var maxPoetByFIO = poets.GetMax(x => x.FIO);

            Console.WriteLine($"Max floats {maxFloat}");
            Console.WriteLine($"Max ints {maxInt}");
            Console.WriteLine($"Max names {maxStr}");
            Console.WriteLine($"Max poet by BirthYear {maxPoetByYear}");
            Console.WriteLine($"Max poet by Name {maxPoetByName}");
            Console.WriteLine($"Max poet by FIO {maxPoetByFIO}");
        }

        class Poet
        {
            public string Name { get; set; }
            public string FIO { get; set; }
            public int BirthYear { get; set; }

            public override string ToString()
            {
                return $"{FIO} {Name} {BirthYear}";
            }
        }
    }
}

