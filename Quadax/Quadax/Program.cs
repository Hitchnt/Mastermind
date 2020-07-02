using System;
using System.Diagnostics;
using System.Linq;

namespace Quadax
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to Mastermind! \n");

            StartGame();
        }

        private static void StartGame()
        {
            try
            {
                string strUserInput = "";
                int intMasterNuber = GenerateNumber();
                int intAttempts = 10;
                string stranswer = "";
                Introduction();

                while (intAttempts >= 1)
                {

                    Console.WriteLine($"Please type in (4) digits in length with each digit between the numbers 1 and 6. Attempts left:{intAttempts} \n" );
                    /** Grab user input */
                    strUserInput= Console.ReadLine();
                    
                    /*make each into an arry to compare them later*/
                    int[] Userdigits = strUserInput.ToString().ToCharArray().Select(Convert.ToInt32).ToArray();
                    int[] Masterdigits = intMasterNuber.ToString().ToCharArray().Select(Convert.ToInt32).ToArray();

                    stranswer = CheckAnswer(Userdigits, Masterdigits);
                    /* T||F see if the answer is correct */
                    if(stranswer == "+ + + + ")
                    {
                        Console.WriteLine("Correct, You Have Won!!  \n");
                        break;
                    }
                    else
                    {
                      
                        Console.WriteLine("Try agien \n");
                    }


                    intAttempts--;
                   
                }
                if (intAttempts <= 0)
                {
                    Console.WriteLine($"Answer was {intMasterNuber}. \n Thanks for playing");
                }

            }
            catch (Exception ex) 
            {

                ErrorLog("You broke the game  \n" + "StackTrace: '{0}'", Environment.StackTrace +"\n" + ex.Message);
            }
        }

        

        private static string CheckAnswer(int[] userdigits, int[] masterdigits)
        {
            string strplusandMinus = "";
            string strplus = "+ ";
            string strminus = "- ";
            string[] strCodeAnswer = new string[] { "", "", "", ""};

           // 2114
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    
                    for (int d = 0; d < 4; d++)
                    {
                        if (userdigits[i] == masterdigits[d]) 
                        {
                            if (i == d)
                            {
                                strCodeAnswer[i] = strplus;
                                break; /* No reason to continue*/
                            }
                            else
                            {                                                           
                               
                                strCodeAnswer[i] = strminus;
                            }
                           
                        }
                    }                   
                }
               
                for (int i = 0; i < 4; i++)
                {
                    strplusandMinus += strCodeAnswer[i];
                }
                Console.WriteLine(strplusandMinus);


                return strplusandMinus;
            }
            catch (Exception ex)
            {

                ErrorLog("You broke the game  \n" + "StackTrace: '{0}'", Environment.StackTrace + "\n" + ex.Message);
            }
            return "0";

        }

        private static void Introduction()
        {
            Console.WriteLine("We have created a four (4) digits in length, with each digit " +
                 "between the numbers 1 and 6 and up to you to solve it you have ten (10)" +
                 "attempts to guess the number correctly before the game its over. \n\r");

            Console.WriteLine("---------------Lets start-----------------\n");
        }

        private static int GenerateNumber()
        {
            /* Create a new 4 digit Number */
            int intGenerateNumber = 0000;
            Random generator = new Random();
            int[] intRandNum = new int[] { 0, 0,0 ,0}; 
            string result = "";

            for (int i = 0; i <= 3; i++)
            { 

                intRandNum[i] = generator.Next(1, 6); /* Only from 1 to 6*/
                result += intRandNum[i].ToString();
            }


            intGenerateNumber = Convert.ToInt32(result);

            return intGenerateNumber;
        }
        private static void ErrorLog(string v1, string v2)
        {
            Console.WriteLine(v1 + v1);
        }
    }
}
