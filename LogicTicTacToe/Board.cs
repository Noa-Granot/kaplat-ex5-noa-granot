namespace NotTicTacToeLogic
{
    public class Board
    {
        private eSymbols[,] m_BoardMatrix;
        private int m_BoardSize;

        public Board(int i_SizeOfBoard)
        {
            m_BoardMatrix = new eSymbols[i_SizeOfBoard, i_SizeOfBoard];
            m_BoardSize = i_SizeOfBoard;
        }

        public eSymbols[,] GetBoard()
        {
            return m_BoardMatrix;
        }

        public eSymbols GetCellSymbol(int i_Row, int i_Col)
        {
            return m_BoardMatrix[i_Row, i_Col];
        }

        public int GetBoardSize()
        {
            return m_BoardSize;
        }

        public bool IsBoardFull(int i_CountTurnsPlayed)
        {
            return i_CountTurnsPlayed == (m_BoardSize * m_BoardSize);
        }

        public bool IsCoordValid(int i_Row, int i_Col)
        {
            return (i_Row >= 0 && i_Row < m_BoardSize) && (i_Col >= 0 && i_Col < m_BoardSize);
        }

        public bool IsCellEmpty(int i_Row, int i_Col)
        {
            return GetCellSymbol(i_Row, i_Col) == eSymbols.Empty;
        }

        public bool HasWinner()
        {
            return hasFullRow() || hasFullCol() || isMainDiagonalFull() || isMainSecondaryFull();
        }

        private bool hasFullRow()
        {
            bool fullRowFound = false;

            for (int i = 0; i < m_BoardSize; i++)
            {
                if (isRowFull(i))
                {
                    fullRowFound = true;
                    break;
                }
            }

            return fullRowFound;
        }

        private bool hasFullCol()
        {
            bool fullColumnFound = false;

            for (int i = 0; i < m_BoardSize; i++)
            {
                if (isColFull(i))
                {
                    fullColumnFound = true;
                    break;
                }
            }

            return fullColumnFound;
        }

        public void MakeMove(int i_Row, int i_Col, eSymbols i_Symbol)
        {
            m_BoardMatrix[i_Row, i_Col] = i_Symbol;
        }

        private bool isRowFull(int i_Row)
        {
            bool streak = true;
            eSymbols firstSignOfTheRow = m_BoardMatrix[i_Row, 0];

            if (firstSignOfTheRow == eSymbols.Empty)
            {
                streak = false;
            }
            else
            {
                for (int i = 1; i < m_BoardSize; i++)
                {
                    eSymbols currentSign = m_BoardMatrix[i_Row, i];

                    if (currentSign != firstSignOfTheRow)
                    {
                        streak = false;
                        break;
                    }
                }
            }

            return streak;
        }

        private bool isColFull(int i_Col)
        {
            bool streak = true;
            eSymbols firstSignOfTheCol = m_BoardMatrix[0, i_Col];

            if (firstSignOfTheCol == eSymbols.Empty)
            {
                streak = false;
            }
            else
            {
                for (int i = 1; i < m_BoardSize; i++)
                {
                    eSymbols currentSign = m_BoardMatrix[i, i_Col];

                    if (currentSign != firstSignOfTheCol)
                    {
                        streak = false;
                        break;
                    }
                }
            }

            return streak;
        }

        private bool isMainDiagonalFull()
        {
            bool streak = true;
            eSymbols firstSignMainDiagonal = m_BoardMatrix[0, 0];

            if (firstSignMainDiagonal == eSymbols.Empty)
            {
                streak = false;
            }
            else
            {
                for (int i = 1; i < m_BoardSize; i++)
                {
                    eSymbols currentSign = m_BoardMatrix[i, i];

                    if (currentSign != firstSignMainDiagonal)
                    {
                        streak = false;
                        break;
                    }
                }
            }

            return streak;
        }

        private bool isMainSecondaryFull()
        {
            bool streak = true;
            eSymbols firstSignSecondoryDiagonal = m_BoardMatrix[0, m_BoardSize - 1];

            if (firstSignSecondoryDiagonal == eSymbols.Empty)
            {
                streak = false;
            }
            else
            {
                for (int currentRow = 1; currentRow < m_BoardSize; currentRow++)
                {
                    eSymbols currentSign = m_BoardMatrix[currentRow, m_BoardSize - (currentRow + 1)];

                    if (currentSign != firstSignSecondoryDiagonal)
                    {
                        streak = false;
                        break;
                    }
                }
            }

            return streak;
        }
    }
}