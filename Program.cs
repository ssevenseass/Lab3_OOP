using System;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            BactrianCamel bactrianCamel = new BactrianCamel();
            SpeedCamel speedCamel = new SpeedCamel();
            Centaur centaur = new Centaur();
            AllTerrainBoots allTerrainBoots = new AllTerrainBoots();
            Broom broom = new Broom();
            MagicCarpet airCarpet = new MagicCarpet();
            Stupa stupa = new Stupa();

            Race<Transport> AirRace = new Race<Transport>("Air transport");
            AirRace.AddTransport(airCarpet);
            AirRace.AddTransport(stupa);
            AirRace.AddTransport(broom);
            AirRace.Win(10000);

            Race<Transport> GroundRace = new Race<Transport>("Ground transport");
            GroundRace.AddTransport(bactrianCamel);
            GroundRace.AddTransport(speedCamel);
            GroundRace.AddTransport(centaur);
            GroundRace.AddTransport(allTerrainBoots);
            GroundRace.Win(10000);

            Race<Transport> MixedRace = new Race<Transport>("Mixed");
            MixedRace.AddTransport(stupa);
            MixedRace.AddTransport(bactrianCamel);
            MixedRace.AddTransport(allTerrainBoots);
            MixedRace.AddTransport(airCarpet);
            MixedRace.Win(10000);

        }
    }
}