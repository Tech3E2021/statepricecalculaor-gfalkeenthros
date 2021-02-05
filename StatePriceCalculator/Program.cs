using System;

namespace StatePriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double InputPrice = 0;
            //Order Value Discount Rate $1000 3% $5000 5% $7000 7% $10000 10% $50000 15%
            //State Tax Rate UT 6.85 % NV 8.00 % TX 6.25 % AL 4.00 % CA 8.25 %
            while (true)
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine("Please type the price first");
                InputPrice = Double.Parse(Console.ReadLine().ToString());
                if (InputPrice == 0)
                {
                    Console.WriteLine("The price has to be above 0");
                }
                else
                {
                    InputPrice *= GetDiscount(InputPrice);
                    Console.WriteLine("Please type state code!");
                    Console.WriteLine("You have 5 choices: UT,NV,TX,AL,CA");
                    double tax = GetStateTax(Enum.Parse<StateCode>(Console.ReadLine()));
                    InputPrice *= tax;
                    Console.WriteLine($"Final price is {InputPrice}");
                }
                Console.WriteLine("Press 'Enter' to start over");
                Console.ReadLine();
                Console.Clear();
            }


        }

        public static double GetDiscount(double price)
        {
            if (price >= 1000 && price < 5000)
            {
                return 0.97;
            }
            else if (price < 7000)
            {
                return 0.95;
            }
            else if (price < 10000)
            {
                return 0.93;
            }
            else if (price < 50000)
            {
                return 0.90;
            }
            else if (price >= 50000)
            {
                return 0.85;
            }
            else
            {
                throw new ArgumentException();
            }

        }

        //Stat kooder og deres moms
        public static double GetStateTax(StateCode stateCode)
        {
            switch (stateCode)
            {
                case StateCode.UT:
                    return 1.0685;
                case StateCode.NV:
                    return 1.08;
                case StateCode.TX:
                    return 1.0625;
                case StateCode.AL:
                    return 1.04;
                case StateCode.CA:
                    return 1.0825;
                default:
                    throw new ArgumentException("Unknown State Code");
            }
        }
    }
    //Alle stater som man kan vælge
    public enum StateCode { UT, NV, TX, AL, CA };
}
