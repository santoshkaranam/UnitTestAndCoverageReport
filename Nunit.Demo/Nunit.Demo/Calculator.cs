using System;

namespace Nunit.Demo
{
    public class Calculator : IDisposable
    {
        public int Addition(int first, int second)
        {
            return first + second;
        }

        public void Dispose()
        {
            // todo
        }

        public int Subtraction(int first, int second)
        {
            if (first < second)
                throw new ArgumentException($"First number {first} is less than second number {second}");

            return first - second;
        }

        public int Multiplication(int first, int second)
        {
            return first * second;
        }

        public double Division(int divident, int divisor)
        {
            if (divisor == 0)
            {
                throw new ArgumentException($"Divisor cannot be zero");

            }

            return divident / divisor;
        }

        public double SquareRoot(int number)
        {
            return Math.Sqrt(number);
        }
    }
}
