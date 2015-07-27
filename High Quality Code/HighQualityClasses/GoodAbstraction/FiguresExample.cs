namespace GoodAbstraction
{
    using System;

    public class FiguresExample 
    {
        public static void Main()
        {
            ICalculate circle = new Circle(5.0);
            Console.WriteLine(circle + Environment.NewLine);

            ICalculate rectangle = new Rectangle(10.2, 5.2);
            Console.WriteLine(rectangle);
        }
    }
}