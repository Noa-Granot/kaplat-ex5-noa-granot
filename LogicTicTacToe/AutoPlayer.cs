using System;
using System.Collections.Generic;

namespace NotTicTacToeLogic
{
    public class AutoPlayer : Player
    {
        private static readonly Random sr_Random = new Random();

        public override bool TryGetMove(out int o_Row, out int o_Col)
        {
            List<int> freeRows = new List<int>();
            List<int> freeCols = new List<int>();
            int boardSize = m_Board.Size;
            bool hasFreeCell;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (m_Board.IsCellEmpty(row, col))
                    {
                        freeRows.Add(row);
                        freeCols.Add(col);
                    }
                }
            }

            o_Row = -1;
            o_Col = -1;
            hasFreeCell = freeRows.Count > 0;

            if (hasFreeCell)
            {
                int index = sr_Random.Next(0, freeRows.Count);
                o_Row = freeRows[index];
                o_Col = freeCols[index];
            }

            return hasFreeCell;
        }
    }
}