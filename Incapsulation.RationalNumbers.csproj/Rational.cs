using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.RationalNumbers
{
    public class Rational
    {
        public bool IsNan = false;
        public int Numerator { get { return numerator; } set { numerator = value; } }
        public int Denominator { get { return denominator; } set { denominator = value; } }

        private int numerator, denominator;

        public Rational(int m, int n = 1)
        {
            if (n == 0 || m == 0)
            {
                IsNan = true;
                Numerator = 0;
                Denominator = 0;
            }
            else if (n % m == 0)
            {
                Numerator = 1;
                Denominator = Math.Abs(n / m);
                if (!(n > 0 && m > 0) && (n > 0 || m > 0))
                    Numerator = -Numerator;
            }
            else
            {
                Numerator = m;
                Denominator = n;
            }
        }

        public static Rational operator+(Rational number1, Rational number2)
        {
            if (number1.IsNan || number2.IsNan) return new Rational(0, 0);
            SetGeneralDenominator(number1, number2);
            return new Rational(number1.Numerator + number2.Numerator, number1.Denominator);
        }

        public static Rational operator -(Rational number1, Rational number2)
        {
            if (number1.IsNan || number2.IsNan) return new Rational(0, 0);
            SetGeneralDenominator(number1, number2);
            return new Rational(number1.Numerator - number2.Numerator, number1.Denominator);
        }

        public static Rational operator *(Rational number1, Rational number2)
        {
            return new Rational(number1.Numerator * number2.Numerator, number1.Denominator * number2.Denominator);
        }

        public static Rational operator /(Rational number1, Rational number2)
        {
            if (number2.Numerator == 0 || number2.Denominator == 0 || number2.IsNan) return new Rational(0, 0);
            return new Rational((number1.Numerator * number2.Denominator), (number1.Denominator * number2.Numerator));
        }

        public static implicit operator double(Rational number)
        {
            return number.Numerator / (double) number.Denominator;
        }

        public static implicit operator int(Rational number)
        {
            if (number.Numerator % number.Denominator == 0)
                return number.Numerator / number.Denominator;
            throw new ArgumentException();
        }

        public static implicit operator Rational(int value)
        {
            return new Rational(value);
        }

        private static void SetGeneralDenominator(Rational number1, Rational number2)
        {
            if (number1.Denominator > number2.Denominator)
            {
                int size = number1.Denominator / number2.Denominator;
                number2.Numerator *= size;
                number2.Denominator *= size;
            }
            else if (number1.Denominator < number2.Denominator)
            {
                int size = number2.Denominator / number1.Denominator;
                number1.Numerator *= size;
                number1.Denominator *= size;
            }
        }
    }
}
