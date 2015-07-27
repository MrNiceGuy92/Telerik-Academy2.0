namespace GoodAbstraction
{
    using System;
    using System.Text;

    public class Rectangle : Figure, ICalculate
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
            : base()
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width 
        {
            get
            {
                return this.width;
            }

            set
            {
                this.ValidateSize(value);
                this.width = value;
            }
        }

        public double Height 
        {
            get
            {
                return this.height;
            }

            set
            {
                this.ValidateSize(value);
                this.height = value;
            }
        }

        public override double CalculateParameter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.AppendLine()
                .AppendFormat("Width: {0}; Height: {1}", this.Width, this.Height);

            return result.ToString();
        }

        private void ValidateSize(double size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("Size must be a positive number.");
            }
        }
    }
}