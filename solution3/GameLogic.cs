using System;
using System.Security.Cryptography;

namespace solution3
{
    class GameLogic
    {
        private string[] parametres { get; set; }
        
        public GameLogic(string[] parametres)
        {
            this.parametres = parametres;
        }

        public string ComputerMove()
        {
            return parametres[RandomNumberGenerator.GetInt32(parametres.Length)];
        }

        public string GameResult(string ComputerParametr, uint UserChoiche)
        {
            uint compuretIndex = UserChoiche;
            if (parametres[UserChoiche] == ComputerParametr)
            {
                return "Draw";
            }
            else
            {
                for (int i = 0; i < parametres.Length / 2; i++)
                {
                    if (++compuretIndex == parametres.Length)
                    {
                        compuretIndex = 0;
                    }

                    if (ComputerParametr == parametres[compuretIndex])
                    {
                        return "Lose";
                    }
                }

                return "Win";
            }
        }

        public void FindWinner(string ComputerParametr, uint UserChoiche)
        {
            string yourState = GameResult(ComputerParametr,UserChoiche);
            if (yourState == "Win")
            {
                Console.WriteLine("Win!");
            }
            else
            {
                if (yourState == "Lose")
                {
                    Console.WriteLine("Lose!");
                }
                else
                {
                    Console.WriteLine("Draw!");
                }
            }
        }
    }
}
