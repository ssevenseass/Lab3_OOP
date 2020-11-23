using System;
using System.Collections.Generic;

namespace Race
{

    public class Race<T>
        where T : Transport
    {

        private readonly string _transportType;
        public Race(string _transportType)
        {
            this._transportType = _transportType;
        }

        public class GroundRace : Race<GroundTransport>
        {
            List<GroundTransport> transports = new List<GroundTransport>();
            public GroundRace(double interval, List<GroundTransport> transports)
                : base("Ground") { }
        }
        public class AirRace : Race<AirTransport>
        {
            public AirRace(double interval, List<AirTransport> transports)
                : base("Air") { }
        }
        public void AddTransport(T valueTransport)
        {
            if (((_transportType != "Air transport") && (_transportType != "Ground transport")) || _transportType == valueTransport.GetTypeOfTransport())
            {
                new LinkedList<T>().AddLast(valueTransport);
            }
            else throw new BadType("Bad type");
        }
        public string Win(double interval)
        {

            double timing;
            double timeOfWin = 0;
            var nameOfWin = "";
            foreach (T value in new LinkedList<T>())
            {
                timing = value.TimeOfRace(interval);
                new Dictionary<string, double>().Add(value.GetTransportName(), timing);
            }

            foreach (var name in new Dictionary<string, double>().Keys)
            {
                if (timeOfWin == 0)
                {
                    timeOfWin = new Dictionary<string, double>()[name];
                    nameOfWin = name;
                }
                else if (timeOfWin > new Dictionary<string, double>()[name])
                {
                    timeOfWin = new Dictionary<string, double>()[name];
                    nameOfWin = name;
                }
            }

            return nameOfWin + timeOfWin;
        }
    }
}