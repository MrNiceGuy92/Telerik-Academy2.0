namespace FigureRotation
{
    using System;

    public class RotatedFigure
    {
        private double width;
        private double height;

        public RotatedFigure(double newWidth, double newHeight)
        {
            this.Width = newWidth;
            this.Height = newHeight;
        }

        public double Width 
        {
            get
            {
                return this.width;
            }

            set
            {
                this.ValidateParameter(value);
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
                this.ValidateParameter(value);
                this.height = value;
            }
        }

        public static RotatedFigure GetRotatedSize(RotatedFigure figure, double angleOfRotation)
        {
            var cosOfAngle = Math.Cos(angleOfRotation);
            var sinOfAngle = Math.Sin(angleOfRotation);

            var newWidth = (Math.Abs(cosOfAngle) * figure.width) + (Math.Abs(sinOfAngle) * figure.height);
            var newHeight = (Math.Abs(sinOfAngle) * figure.width) + (Math.Abs(cosOfAngle) * figure.height);

            RotatedFigure rotatedFigure = new RotatedFigure(newWidth, newHeight);

            return rotatedFigure;
        }

        private void ValidateParameter(double parameter)
        {
            if (parameter <= 0)
            {
                throw new ArgumentException("Size must be a positive number.");
            }
        }
    }
}