namespace LoopRefactoring
{
    using System;

    public class Loop
    {
        public static void Main()
        {
            int[] array = new int[100];
            Random randomElementGenerator = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomElementGenerator.Next(100);
            }

            int expectedValue = 30;
            bool isValueFound = false;

            for (int index = 0; index < 100; index++)
            {
                if (index % 10 == 0)
                {
                    if (array[index] == expectedValue)
                    {
                        isValueFound = true;
                    }
                }

                Console.WriteLine(array[index]);
            }

            // More code here
            if (isValueFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}