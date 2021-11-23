using System;
using System.Linq;

namespace AdventDay1
{
    class DoTheThing
    {

        public static string input;                 //text input
        public static string[] cInput;              //split input
        public static long[] output = new long[0];  //declare as we need to check contents once before it's initialised. we use long as we could handle big numbers.

        public static void Main(string[] args)
        {
            input = System.IO.File.ReadAllText("input.txt");            //pull file
            cInput = input.Split(Environment.NewLine.ToCharArray());    //split new lines
            Console.WriteLine("--Two Numbers--");
            TwoNumbers();
            Console.WriteLine("--Three Numbers--");
            ThreeNumbers();
            Console.ReadLine();
        }

        public static void TwoNumbers()
        {
            int i = 0;                          //how many unique results we have

            foreach (string a in cInput)        //iterate first number
            {
                foreach (string b in cInput)    //iterate second number
                {
                    if (a == b) continue;       //escape if we're checking a number against itself (123 + 123)
                    else
                    {
                        long checkA = Convert.ToInt64(a), checkB = Convert.ToInt64(b);          //assign once each iteration so we're not converting every Contains() iteration.

                        if (checkA + checkB == 2020 && !output.Contains(checkA * checkB))       //check if = 2020 and removes duplicates ("123 + 456" and "456" + "123")
                        {
                            i++;
                            Console.WriteLine("{0} + {1} = 2020", a, b);
                            Array.Resize(ref output, i);                                       //resize our output Array dependent on results. Yes I should've used a list.
                            output[i - 1] = checkA * checkB;                                   //Reduce by 1 before assignment to array, as we're using an iteration integer.
                            Console.WriteLine("{0} * {1} = {2}", a, b, output[i - 1]);  
                        };
                    }
                }
            }

            Console.WriteLine("The highest value is {0}", output.Max());                //et voilà
        }

        public static void ThreeNumbers()
        {
            int i = 0;

            foreach (string a in cInput)
            {
                foreach (string b in cInput)
                {
                    foreach (string c in cInput) //iterate third number
                    {
                        if (a == b || b == c || c == a) continue;       //escape if we're checking a number against itself (123 + 456 + 123)
                        else
                        {
                            long checkA = Convert.ToInt64(a), checkB = Convert.ToInt64(b), checkC = Convert.ToInt64(c);

                            if (checkA + checkB + checkC == 2020 && !output.Contains(checkA * checkB * checkC))
                            {
                                i++;
                                Console.WriteLine("{0} + {1} + {2} = 2020", a, b, c);
                                Array.Resize(ref output, i);
                                output[i - 1] = checkA * checkB * checkC;
                                Console.WriteLine("{0} * {1} * {2} = {3}", a, b, c, output[i - 1]);
                            };
                        }
                    }
                }
            }
            Console.WriteLine("The highest value is {0}", output.Max());                //et voilà but bigger
        }
        
    }
}
