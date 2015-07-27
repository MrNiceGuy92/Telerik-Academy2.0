namespace CohesionAndCoupling
{
    using System;

    public class Parallelepiped
    {
        private double width;
        private double height;
        private double depth;

        public Parallelepiped(double newWidth, double newHeight, double newDepth)
        {
            this.Width = newWidth;
            this.Height = newHeight;
            this.Depth = newDepth;
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

        public double Depth 
        {
            get
            {
                return this.depth;
            }

            set
            {
                this.ValidateSize(value);
                this.depth = value;
            }
        }

        public double CalculateVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalculateDiagonalXYZ()
        {
            double distance = DistanceUtils.CalculateDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalculateDiagonalXY()
        {
            double distance = DistanceUtils.CalculateDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalculateDiagonalXZ()
        {
            double distance = DistanceUtils.CalculateDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalculateDiagonalYZ()
        {
            double distance = DistanceUtils.CalculateDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }

        private void ValidateSize(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Value of size must be a positie number.");
            }
        }
    }
}