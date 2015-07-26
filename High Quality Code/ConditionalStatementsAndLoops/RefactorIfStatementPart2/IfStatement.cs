namespace RefactorIfStatementPart2
{
    using System;

    public class IfStatement
    {
        public static void Main()
        {
            const int MAX_X = 100;
            const int MAX_Y = 200;
            const int MIN_X = 50;
            const int MIN_Y = 100;

            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            bool hasBeenVisit = true;
            bool isYInRange = MIN_Y <= y && y <= MAX_Y;
            bool isXInRange = MIN_X <= x && x <= MAX_X;
            bool areBothXAndYInRange = isXInRange && isYInRange;

            if (areBothXAndYInRange && !hasBeenVisit) 
            {
                VisitCell();
            }
        }

        private static void VisitCell()
        {
            throw new System.NotImplementedException();
        }
    }
}