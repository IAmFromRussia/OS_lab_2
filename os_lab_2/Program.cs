using System;
using System.Threading;

namespace os_lab_2
{
    class Program
    {
        private string Current { get; set; } = "1234567890";
        
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;

            var currentString = "1234567890";
            Console.WriteLine("Press the Escape (Esc) key to quit: \n");
            Console.WriteLine("Current string: {0}", currentString);

            var one = "";
            var two = "";
            
            do
            {
                cki = Console.ReadKey();

                Console.Write(" --> ");
                
                if (cki.Key == ConsoleKey.Backspace)
                {
                    var backspaceThread = new Thread(() => two = BackSpaceOperation(cki, one));
                    backspaceThread.Start();
                    currentString = two;
                    backspaceThread.Interrupt();
                    Console.WriteLine("Result bck: {0}", currentString);
                    continue;
                }
                
                var numbersThread = new Thread(() => one = NumberKeysOperations(cki, currentString));
                
                numbersThread.Start();
                currentString = one;
                numbersThread.Interrupt();
                
                Console.WriteLine("Result: {0}\n one - {1}\n two - {2}", currentString, one, two);

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
                        return currentString;
                    }

                    if (currentString.Length >= 5)
                    {
                        currentString = currentString.Remove(currentString.Length - 6);
                        Console.WriteLine("From method: {0}", currentString);
                        return currentString;
                    }

                    var warning = "\nWARNING!\n" +
                                  "Add Symbols!\n" +
                                  "Current string: " + currentString + "\n" +
                                  "Amount of symbols: " + currentString.Length;
                    Console.WriteLine(warning);
                    return currentString;
                }
    }
}