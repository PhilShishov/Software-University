namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }

        public int EngineSpeed { get; set; }

        public int EnginePower { get; set; }
    }
}
