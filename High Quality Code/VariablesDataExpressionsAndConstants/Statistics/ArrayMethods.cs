namespace Statistics
{
    public class ArrayMethods
    {
        public void PrintArrayStatistics(double[] array)
        {
            this.PrintMax(array);
            this.PrintMin(array);
            this.PrintAverage(array);
        }

        private double PrintMax(double[] array)
        {
            double maxElement = double.MinValue;

            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] > maxElement)
                {
                    maxElement = array[index];
                }
            }

            return maxElement;
        }

        private double PrintMin(double[] array)
        {
            double minElement = double.MaxValue;

            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] < minElement)
                {
                    minElement = array[index];
                }
            }

            return minElement;
        }

        private double PrintAverage(double[] array)
        {
            double sum = 0;

            for (int index = 0; index < array.Length; index++)
            {
                sum = array[index];
            }

            double average;
            average = sum / array.Length;
            return average;
        }
    }
}