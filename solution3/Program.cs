using System;
using System.Linq;
using System.Text;

namespace solution3
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string[] parametrs = args;
            const int keySize = 16;
            try
            {
                CheckParameters(args);
                while (true)
                {
                    var gameLogic = new GameLogic(parametrs);
                    string ComputerChoiche = gameLogic.ComputerMove();
                    var HMACGenerator = new HMACGenerator(Encoding.Default.GetBytes(ComputerChoiche), keySize);
                    HMACGenerator.OutputHMAC();
                    PrintMenu(parametrs);

                    string Choiche = Console.ReadLine();

                    if (Choiche == "?")
                    {
                        HelpTable.PrintHelpTable(parametrs);
                        Console.WriteLine("Press any button to continue...");
                        Console.ReadLine();
                    }
                    else if (uint.TryParse(Choiche, out uint signNumber) && (signNumber <= parametrs.Length))
                    {
                        if (signNumber == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Your move: {parametrs[signNumber - 1]}");
                            Console.WriteLine($"Computer move: {ComputerChoiche}");
                            gameLogic.FindWinner(ComputerChoiche, signNumber - 1);
                            HMACGenerator.OutputKey();
                            Console.WriteLine("Press any button to continue...");
                            Console.ReadLine();
                            break;
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Correct entry of parameters: Rock Paper Scissors etc");
            }
        }
        
        static void PrintMenu(string[] parameters)
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < parameters.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {parameters[i]}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
            Console.Write("Enter your move: ");
        }

        static void CheckParameters(string[] args)
        {
            if (args.Length < 3)
            {
                throw new ArgumentException("Wrong number of parameters - must be more than 3");
            }
            else if (args.Length % 2 != 1)
            {
                throw new ArgumentException("Wrong number of parameters - must be odd");
            }
            else if (args.Length != args.Distinct().Count())
            {
                throw new ArgumentException("Wrong names of parametres - must be unique");
            }
        }
    }
}
