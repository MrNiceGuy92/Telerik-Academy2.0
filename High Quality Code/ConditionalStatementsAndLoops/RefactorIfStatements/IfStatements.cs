namespace RefactorIfStatements
{
    public class IfStatements
    {
        public static void Main()
        {
            Potato potato = new Potato();

            if (potato != null) 
            {
                bool cookCondition = potato.HasBeenPeeled && !potato.IsRotten;
                if (cookCondition)
                {
                    Cook(potato);
                }
            }  
        }

        private static void Cook(Potato potato)
        {
            throw new System.NotImplementedException();
        }
    }
}