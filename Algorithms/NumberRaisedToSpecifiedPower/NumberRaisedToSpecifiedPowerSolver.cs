namespace Algorithms.NumberRaisedToSpecifiedPower
{
    public class NumberRaisedToSpecifiedPowerSolver
    {
        public static double SlowSolve(double number, double power)
        {
            if (power is 0)
            {
                return 1;
            }

            return number * SlowSolve(number, power - 1);
        }
        
        public static double FastSolve(double number, double power)
        {
            if (power is 0)
            {
                return 1;
            }

            if (power % 2 == 1)
            {
                return number * FastSolve(number, power - 1);
            }

            double middle = FastSolve(number, power / 2);
            return middle * middle;
        }
    }
}