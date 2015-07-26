namespace QualityMethods
{
    using System;

    internal class Methods
    {
        internal static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            ValidateSides(sideA, sideB, sideC);
            CheckTriangleInequality(sideA, sideB, sideC);
           
            double halfParameter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(halfParameter * (halfParameter - sideA) * (halfParameter - sideB) * (halfParameter - sideC));
            return area;
        }

        internal static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid number!");
            }
        }

        internal static int FindMaxArrayElement(params int[] elements)
        {
            ValidateArrayElement(elements);

            int maxElement = int.MinValue;
            for (int index = 1; index < elements.Length; index++)
            {
                if (elements[index] > elements[0])
                {
                    maxElement = elements[index];
                }
            }

            return maxElement;
        }

        internal static void PrintAsNumber(double number, string format)
        {
            switch (format)
            {
                case "round": Console.WriteLine("{0:f2}", number); 
                    break;
                case "percent": Console.WriteLine("{0:p0}", number); 
                    break;
                case "align right": Console.WriteLine("{0,8}", number); 
                    break;
                default: Console.WriteLine("Invalid format command!"); 
                    break;
            }
        }

        internal static double CalculateDistance(
                                                double firstXCoordinate, 
                                                double firstYCoordinate, 
                                                double secondXCoordinate, 
                                                double secondYCoordinate)
        {
            double subtractionProductX = secondXCoordinate - firstXCoordinate;
            double subtractionProductY = secondYCoordinate - firstYCoordinate;

            double distance = Math.Sqrt((subtractionProductX * subtractionProductX) + (subtractionProductY * subtractionProductY));
            return distance;
        }

        internal static void IsLineHorizontal(
                                            double firstXCoordinate, 
                                            double firstYCoordinate, 
                                            double secondXCoordinate,
                                            double secondYCoordinate)
        {
            bool isHorizontal = false;
            
            if (firstXCoordinate == secondXCoordinate)
            {
                isHorizontal = true;
            }

            Console.WriteLine("Is line horizontal: " + isHorizontal);            
        }

        internal static void IsLineVertical(
                              double firstXCoordinate, 
                              double firstYCoordinate, 
                              double secondXCoordinate,
                              double secondYCoordinate)
        {
            bool isVertical = false;

            if (firstYCoordinate == secondYCoordinate)
            {
                isVertical = true;
            }

            Console.WriteLine("Is line vertical: " + isVertical);
        }

        private static void ValidateSides(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Sides of triangle must be positive.");
            }
        }

        private static void CheckTriangleInequality(double sideA, double sideB, double sideC)
        {
            bool triangleInequalityConditions = sideA + sideB < sideC || sideA + sideC < sideB || sideB + sideC < sideA;

            if (triangleInequalityConditions)
            {
                throw new ArgumentException("Triangle equality is not satisfied.");
            }
        }

        private static void ValidateArrayElement(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Array cannot have null elements.");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.");
            }
        }
    }
}