using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;

namespace Race
{
    public abstract class Transport
    {
        private readonly string _transportName;
        private readonly double _transportSpeed;
        private readonly string _transportType;

        protected Transport(string _transportName, double _transportSpeed, string _transportType)
        {
            this._transportName = _transportName;
            this._transportSpeed = _transportSpeed;
            this._transportType = _transportType;
        }

        public string GetTransportName() => this._transportName;

        public double GetSpeed() => this._transportSpeed;


        public string GetTypeOfTransport() => this._transportType;

        public abstract double TimeOfRace(double interval);

    }
    public abstract class AirTransport : Transport
    {
        protected AirTransport(string name, double speed) : base(name, speed, "Air")
        { }

        protected abstract double DistanceReducer(double interval);
        public override double TimeOfRace(double interval) => this.DistanceReducer(interval) / this.GetSpeed();

    }
    public class MagicCarpet : AirTransport
    {
        public MagicCarpet() : base("Magic carpet", 10) { }
        protected override double DistanceReducer(double interval)
        {
            if (interval < 1000)
            {
                return interval;
            }
            else if ((interval >= 1000) && (interval < 5000))
            {
                interval -= interval * 0.03;
                return interval;
            }
            else if ((interval >= 5000) && (interval < 10000))
            {
                interval -= interval * 0.1;
                return interval;
            }
            else if (interval > 10000)
            {
                interval -= interval * 0.05;
                return interval;
            }
            return 0;
        }
    }
    public class Broom : AirTransport
    {
        public Broom() : base("Broom", 20) { }
        protected override double DistanceReducer(double interval)
        {

            for (int i = 0; i < (interval / 1000); i++)
            {
                interval -= interval * 0.01;
            }
            return interval;
        }
    }
    public class Stupa : AirTransport
    {
        public Stupa() : base("Stupa", 8) { }
        protected override double DistanceReducer(double interval) => interval -= interval * 0.06;
    }
    public abstract class GroundTransport : Transport
    {
        protected GroundTransport(string name, double speed) : base(name, speed, "Ground transport")
        { }
        protected float RestInterval;
        protected abstract float RestDuration();
        public override Double TimeOfRace(double interval)
        {
            Double time = 0, currentDistance = 0;

            while (currentDistance < interval)
            {
                currentDistance += this.GetSpeed() * this.RestInterval;
                if (currentDistance >= interval)
                {
                    time += this.RestInterval - ((currentDistance - interval) / this.GetSpeed());
                }
                else
                {
                    time += this.RestInterval + this.RestDuration();
                }
            }
            return time;
        }
    }
    public class AllTerrainBoots : GroundTransport
    {

        private bool restFirst;

        public AllTerrainBoots() : base("AllTerrainBoots", 6) => this.RestInterval = 60;

        protected override float RestDuration()
        {
            if (this.restFirst)
            {
                this.restFirst = false;
                return 10;
            }
            else
            {
                return 5;
            }
        }
    }
    public class BactrianCamel : GroundTransport
    {
        private bool isFirstRest;
        public BactrianCamel() : base("BactrianCamel", 10) => this.RestInterval = 30;

        protected override float RestDuration()
        {
            if (this.isFirstRest)
            {
                this.isFirstRest = false;
                return 2;
            }
            else
            {
                return 8;
            }
        }
    }
    public class Centaur : GroundTransport
    {
        public Centaur() : base("Centaur", 15) => this.RestInterval = 8;



        public bool RestFirst { get; }

        protected override float RestDuration() => 2;
    }

    public class SpeedCamel : GroundTransport
    {
        protected bool restFirst;

        protected bool restSecond;

        public SpeedCamel() : base("SpeedboatCamel", 40) => this.RestInterval = 10;


        protected override float RestDuration()
        {
            if (restFirst)
            {
                restFirst = false;
                return 5;
            }
            else if (restSecond)
            {
                restSecond = false;
                return (float)6.5;
            }
            else
            {
                return 8;

            }
        }


    }