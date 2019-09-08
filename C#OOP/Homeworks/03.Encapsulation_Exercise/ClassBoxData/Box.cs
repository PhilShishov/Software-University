using System;
using System.Reflection;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        //length, width and height
        private double length;
        private double width;
        private double height;
        //PropertyInfo propertyInfo;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;

            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException($"Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;

            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException($"Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;

            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException($"Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            double result = 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
            return result;
        }

        public double LateralSurfaceArea()
        {
            double result = 2 * this.Length * this.Height + 2 * this.Width * this.Height;
            return result;
        }

        public double Volume()
        {
            double result = this.Length * this.Width * this.Height;
            return result;
        }
    
        //private void ValidateBoxSide(double value)
        //{
        //    //propertyInfo = value.GetType().GetProperty();

        //    if (value <= 0)
        //    {
        //        throw new ArgumentException($"{propertyInfo.Name} cannot be zero or negative.");
        //    }
        //}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.SurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {this.Volume():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
