using System;

namespace NotTicTacToeLogic
{
    public class Board
    {
        private readonly eSymbols[,] r_BoardMatrix;
        private readonly int r_BoardSize;
        private int m_LastChangedRow;
        private int m_LastChangedCol;

        public event Action<Board> CellChanged;

        public Board(int i_SizeOfBoard)
        {
            r_BoardMatrix = new eSymbols[i_SizeOfBoard, i_SizeOfBoard];
            r_BoardSize = i_SizeOfBoard;
        }

        public int Size
        {
            get { return r_BoardSize; }
        }

        public int LastChangedRow
        {
            get { return m_LastChangedRow; }
        }

        public int LastChangedCol
        {
            get { return m_LastChangedCol; }
        }

        public eSymbols this[int i_Row, int i_Col]
        {
            get { return r_BoardMatrix[i_Row, i_Col]; }
        }

        public void MakeMove(int i_Row, int i_Col, eSymbols i_Symbol)
        {
            setCell(i_Row, i_Col, i_Symbol);
        }

        public void Reset()
        {
            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    setCell(row, col, eSymbols.Empty);
                }
            }
        }

        private void setCell(int i_Row, int i_Col, eSymbols i_Symbol)
        {
            r_BoardMatrix[i_Row, i_Col] = i_Symbol;
            m_LastChangedRow = i_Row;
            m_LastChangedCol = i_Col;
            OnCellChanged();
        }

        protected virtual void OnCellChanged()
        {
            if (CellChanged != null)
            {
                CellChanged.Invoke(this);  
            }
        }

        public bool IsBoardFull(int i_CountTurnsPlayed)
        {
            return i_CountTurnsPlayed == (r_BoardSize * r_BoardSize);
        }

        public bool IsCoordValid(int i_Row, int i_Col)
        {
            return (i_Row >= 0 && i_Row < r_BoardSize) && (i_Col >= 0 && i_Col < r_BoardSize);
        }

        public bool IsCellEmpty(int i_Row, int i_Col)
        {
            return this[i_Row, i_Col] == eSymbols.Empty;
        }

        public bool HasWinner()
        {
            return hasWinningRow()
                || hasWinningColumn()
                || isLineFull(0, 0, 1, 1)
                || isLineFull(0, r_BoardSize - 1, 1, -1);
        }

        private bool hasWinningRow()
        {
            bool winningRowFound = false;

            for (int row = 0; row < r_BoardSize; row++)
            {
                if (isLineFull(row, 0, 0, 1))
                {
                    winningRowFound = true;
                    break;
                }
            }

            return winningRowFound;
        }

        private bool hasWinningColumn()
        {
            bool winningColumnFound = false;

            for (int col = 0; col < r_BoardSize; col++)
            {
                if (isLineFull(0, col, 1, 0))
                {
                    winningColumnFound = true;
                    break;
                }
            }

            return winningColumnFound;
        }

        private bool isLineFull(int i_StartRow, int i_StartCol, int i_RowStep, int i_ColStep)
        {
            bool streak = true;
            eSymbols firstSign = r_BoardMatrix[i_StartRow, i_StartCol];

            if (firstSign == eSymbols.Empty)
            {
                streak = false;
            }
            else
            {
                int row = i_StartRow + i_RowStep;
                int col = i_StartCol + i_ColStep;

                for (int i = 1; i < r_BoardSize; i++)
                {
                    if (r_BoardMatrix[row, col] != firstSign)
                    {
                        streak = false;
                        break;
                    }

                    row += i_RowStep;
                    col += i_ColStep;
                }
            }

            return streak;
        }
    }
}