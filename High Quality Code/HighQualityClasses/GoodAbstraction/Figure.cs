namespace GoodAbstraction
{
    using System;
    using System.Text;

    public abstract class Figure : ICalculate
    {
        public Figure()
        {
        }

        public abstract double CalculateParameter();

        public abstract double CalculateSurface();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0}", this.GetType().Name).AppendLine();
            result.AppendFormat("Area: {0:F4}; Perimeter: {1:F4}", this.CalculateSurface(), this.CalculateParameter());

            return result.ToString();
        }
    }
}