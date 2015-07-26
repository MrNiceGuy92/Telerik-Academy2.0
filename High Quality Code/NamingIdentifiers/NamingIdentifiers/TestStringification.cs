namespace Stringification
{
    using System;

    public class TestStringification
    {
        public static void Мain()
        {
            BoolStringification instance = new BoolStringification();
            instance.ConvertBoolToString(true);
            Console.WriteLine(instance);
        }
    }
}