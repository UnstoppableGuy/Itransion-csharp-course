using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTables;

namespace solution3
{
    class HelpTable
    {
        public static void PrintHelpTable(string[] parameters)
        {
            var table = new ConsoleTable("User \\ Сomputer");
            var gameLogic = new GameLogic(parameters);

            for (uint i = 0; i < parameters.Length; i++)
            {
                table.Columns.Add(parameters[i]);
                string[] row = new string[parameters.Length + 1];
                row[0] = parameters[i];
                for (uint j = 0; j < parameters.Length; j++)
                {
                    row[j + 1] = gameLogic.GameResult(parameters[j],i);
                }

                table.Rows.Add(row);
            }
            table.Write(Format.Alternative);
        }

    }
}
