namespace P08
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        private const string DefaultValueString = "n/a";
        private const int DefaultValueInt = -1;
        public Car(string model, Engine engine, double weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }
        public Car(string model, Engine engine, double weight)
            : this(model, engine, weight, DefaultValueString)
        {
        }
        public Car(string model, Engine engine, string color)
            : this(model, engine, DefaultValueInt, color)
        {
        }
        public Car(string model, Engine engine)
            : this(model, engine, DefaultValueInt, DefaultValueString)
        {
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public double Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.Model}:");
            stringBuilder.AppendLine($"{Engine}");
            stringBuilder.AppendLine(this.Weight == -1 ? $"  Weight: n/a" : $"  Weight: {this.Weight}");
            stringBuilder.Append($"  Color: {this.Color}");

            return stringBuilder.ToString();
        }
    }
}
