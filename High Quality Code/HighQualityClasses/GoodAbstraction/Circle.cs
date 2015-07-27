namespace GoodAbstraction
{
    using System;
    using System.Text;

    public class Circle : Figure, ICalculate
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius 
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius must be a positive number.");
                }

                this.radius = value;
            }
        }

        public override double CalculateParameter()
        {
            double parameter = 2 * Math.PI * this.Radius;
            return parameter;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.AppendLine()
                .AppendFormat("Radius: {0}", this.Radius);

            return result.ToString();
        }
    }
}