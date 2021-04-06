namespace DefaultNamespace
{
	public class Program
	{
		using System;
using System.Diagnostics;
using System.Threading;

namespace Test
{
    class Program
    {
        private string Current { get; set; } = "0123456789";
        
        static void Main(string[] args)
        {

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;

            Console.WriteLine("Press the Escape (Esc) key to quit: \n");
            Console.WriteLine("Current string: {0}", );

            
            do
            {
                cki = Console.ReadKey();
                Console.Write(" --> ");

                var numbersThread = new Thread(() => NumberKeysOperations(cki, currentString));
                var backspaceThread = new Thread(() => BackSpaceOperation(cki, currentString));
                
                if (cki.Key == ConsoleKey.Backspace)
                {
                    backspaceThread.Start();
                }
                
                numbersThread.Start();
                
                Console.WriteLine("Result: {0}", currentString);


            } while (cki.Key != ConsoleKey.Escape);
        }
        
        private static string NumberKeysOperations(ConsoleKeyInfo currentKey, string currentString)
        {
            switch (currentKey.Key)
            {
                case ConsoleKey.D0:
                    currentString += "0";
                    return currentString;
                case ConsoleKey.D1:
                    currentString += "1";
                    return currentString;
                case ConsoleKey.D2:
                    currentString += "2";
                    return currentString;
                case ConsoleKey.D3:
                    currentString += "3";
                    return currentString;
                case ConsoleKey.D4:
                    currentString += "4";
                    return currentString;
                case ConsoleKey.D5:
                    currentString += "5";
                    return currentString;
                case ConsoleKey.D6:
                    currentString += "6";
                    return currentString;
                case ConsoleKey.D7:
                    currentString += "7";
                    return currentString;
                case ConsoleKey.D8:
                    currentString += "8";
                    return currentString;
                case ConsoleKey.D9:
                    currentString += "9";
                    return currentString;
                default:
                    Console.WriteLine("This key doesn't exist..");
                    break;
            }

            return currentString;
        }

        private static string BackSpaceOperation(ConsoleKeyInfo currentKey, string currentString)
        {

            if (string.IsNullOrEmpty(currentString))
            {
                Console.WriteLine("string is empty! Add symbols");
            }
            else if (currentString.Length >= 5)
            {
                currentString = currentString.Remove(currentString.Length - 5);
                return currentString;
            }
            else
            {
                var warning = "\nWARNING!\n" +
                              "Add Symbols!\n" +
                              "Current string: " + currentString + "\n" +
                              "Amount of symbols: " + currentString.Length;
                Console.WriteLine(warning);
            }

            return currentString;
        }
    }
}
	}
}