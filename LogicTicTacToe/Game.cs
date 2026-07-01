namespace NotTicTacToeLogic
{
    public enum eSymbols
    {
        Empty = 0,
        X = 'X',
        O = 'O'
    }
    
    public class Game
    {
        private Board m_BoardManager;
        private Player[] m_Players = null;
        private int m_CountTurns = 0;

        public void InitializeGame(int i_BoardSize, bool i_SecondPlayerIsComputer)
        {
            m_CountTurns = 0;
            m_BoardManager = new Board(i_BoardSize);
            if (m_Players == null)
            {
                m_Players = new Player[2];
                m_Players[0] = new HumanPlayer();

                if (i_SecondPlayerIsComputer)
                {
                    m_Players[1] = new AutoPlayer();
                }
                else
                {
                    m_Players[1] = new HumanPlayer();
                }
            }

            m_Players[0].SetBoard(m_BoardManager);
            m_Players[1].SetBoard(m_BoardManager);
        }

        public void ResetGame()
        {
            m_BoardManager = new Board(m_BoardManager.GetBoardSize());
            m_Players[0].SetBoard(m_BoardManager);
            m_Players[1].SetBoard(m_BoardManager);
            m_CountTurns = 0;
        }

        public bool TryToPlayTurn(int i_Row, int i_Col, out bool o_CellIsOccupied)
        {
            bool turnIsValid = true;
            o_CellIsOccupied = false;

            //if (!m_Board.CheckIfValidCoord(i_Row, i_Col))
            //{
            //    turnIsValid = false;
            //}
            //else if (!m_Board.CheckIfCellIsEmpty(i_Row, i_Col))
            //{
            //    o_CellIsOccupied = true;
            //    //turnIsValid = false;
            //}
            //else
            //{
            //    m_Board.MakeMove(i_Row, i_Col, m_Players[m_CurrentTurn].GetSymbol());
            //    m_CurrentTurn = (m_CurrentTurn + 1) % 2;
            //}

            if (!m_BoardManager.IsCoordValid(i_Row, i_Col))
            {
                turnIsValid = false;
            }
            else if (!m_BoardManager.IsCellEmpty(i_Row, i_Col))
            {
                o_CellIsOccupied = true;
                turnIsValid = false;
            }
            else
            {
                m_BoardManager.MakeMove(i_Row, i_Col, m_Players[m_CountTurns % 2].GetSymbol());
                m_CountTurns = m_CountTurns + 1;
            }

            return turnIsValid;    
        }

        public bool IsGameOver(out bool o_BoardIsFull, out int o_WinnerId)
        {
            //int currentTurnPlayerId = m_CountTurns;
            bool gameOver = false;
            o_BoardIsFull = false;
            o_WinnerId = -1;

            if (m_BoardManager.HasWinner())
            {
                gameOver = true;
                m_Players[(m_CountTurns) % 2].IncrementScore();
                o_WinnerId = m_Players[(m_CountTurns) % 2].GetId();
            }
            else if (m_BoardManager.IsBoardFull(m_CountTurns))
                {
                o_BoardIsFull = true;
                gameOver = true;
            }

            return gameOver;
        }

        public eSymbols[,] GetBoard()
        {
            return m_BoardManager.GetBoard();
        }

        public Player GetCurrentPlayer()
        {
            return m_Players[m_CountTurns % 2];
        }

        public Player[] GetPlayers()
        {
            return m_Players;
        }
    }
}
