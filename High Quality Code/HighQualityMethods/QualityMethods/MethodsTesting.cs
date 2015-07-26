namespace QualityMethods
{
    using System;

    public class MethodsTesting
    {
        public static void Main()
        {
            Console.WriteLine("Area: " + Methods.CalculateTriangleArea(3, 4, 5));

            Console.WriteLine("Number to digit: " + Methods.NumberToDigit(5));

            Console.WriteLine("Max element: " + Methods.FindMaxArrayElement(5, -1, 3, 2, 14, 2, 3));

            Console.WriteLine("Print as Number: ");
            Methods.PrintAsNumber(1.3, "round");
            Methods.PrintAsNumber(0.75, "percent");
            Methods.PrintAsNumber(2.30, "align right");

            Console.WriteLine("Distance: " + Methods.CalculateDistance(3, -1, 3, 2.5));
            Methods.IsLineHorizontal(3, -1, 3, 2.5);
            Methods.IsLineVertical(3, -1, 3, 2.5);

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 03, 17), "From Sofia"); 

            Student stella = new Student("Stella", "Markova", new DateTime(1993, 03, 11), "From Vidin, gamer, high results");

            Console.WriteLine(
                                "{0} older than {1} -> {2}",
                                peter.FirstName,
                                stella.FirstName,
                                peter.IsOlder(stella));
        }
    }
}