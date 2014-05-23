namespace RefactorStatements
{
    public class RefactorStatements
    {
        private static void Main(string[] args)
        {
            Potato potato;

            // ... 
            if (potato != null)
            {
                if (potato.HasBeenPeeled && potato.IsEdible)
                {
                    Cook(potato);
                }
            }

            if (IsInRange(x, Min_X, Max_X) && IsInRange(y, Min_Y, Max_Y) && shouldVisitCell)
            {
                VisitCell();
            }
        }

        private static bool IsInRange(int variable, int minRange, int maxRange)
        {
            if (variable >= minRange && variable <= maxRange)
            {
                return true;
            }

            return false;
        }
    }
}