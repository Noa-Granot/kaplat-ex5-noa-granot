using System;

namespace NotTicTacToeLogic
{
    public class Game
    {
        private const int k_NumberOfPlayers = 2;

        private readonly Player[] r_Players;
        private readonly int r_BoardSize;
        private readonly Board r_BoardManager;
        private int m_CountTurns;

        public event Action<Game> CellChanged;

        public Game(int i_BoardSize, bool i_SecondPlayerIsComputer, string i_FirstPlayerName, string i_SecondPlayerName)
        {
            r_BoardSize = i_BoardSize;
            r_Players = new Player[k_NumberOfPlayers];
            r_Players[0] = new HumanPlayer();

            if (i_SecondPlayerIsComputer)
            {
                r_Players[1] = new AutoPlayer();
            }
            else
            {
                r_Players[1] = new HumanPlayer();
            }

            r_Players[0].Name = i_FirstPlayerName;
            r_Players[1].Name = i_SecondPlayerName;

            r_BoardManager = new Board(r_BoardSize);
            r_BoardManager.CellChanged += r_BoardManager_CellChanged;   // Game listens to its board

            foreach (Player player in r_Players)
            {
                player.SetBoard(r_BoardManager);
            }

            StartNewRound();
        }

        private void r_BoardManager_CellChanged(Board sender)
        {
            OnCellChanged();
        }

        protected virtual void OnCellChanged()
        {
            if (CellChanged != null)
            {
                CellChanged.Invoke(this);   
            }
        }

        public int LastChangedRow
        {
            get { return r_BoardManager.LastChangedRow; }
        }

        public int LastChangedCol
        {
            get { return r_BoardManager.LastChangedCol; }
        }

        public eSymbols GetSymbolAt(int i_Row, int i_Col)
        {
            return r_BoardManager[i_Row, i_Col];
        }

        public void StartNewRound()
        {
            m_CountTurns = 0;
            r_BoardManager.Reset();
        }

        public bool TryToPlayTurn(int i_Row, int i_Col, out bool o_CellIsOccupied)
        {
            bool turnIsValid = true;
            o_CellIsOccupied = false;

            if (!r_BoardManager.IsCoordValid(i_Row, i_Col))
            {
                turnIsValid = false;
            }
            else if (!r_BoardManager.IsCellEmpty(i_Row, i_Col))
            {
                o_CellIsOccupied = true;
                turnIsValid = false;
            }
            else
            {
                r_BoardManager.MakeMove(i_Row, i_Col, r_Players[m_CountTurns % k_NumberOfPlayers].Symbol);
                m_CountTurns++;
            }

            return turnIsValid;
        }

        public bool TryGetComputerMove(out int o_Row, out int o_Col)
        {
            return r_Players[m_CountTurns % k_NumberOfPlayers].TryGetMove(out o_Row, out o_Col);
        }

        public bool IsGameOver(out bool o_BoardIsFull, out int o_WinnerId)
        {
            bool gameOver = false;
            o_BoardIsFull = false;
            o_WinnerId = -1;

            if (r_BoardManager.HasWinner())
            {
                gameOver = true;
                r_Players[m_CountTurns % k_NumberOfPlayers].IncrementScore();
                o_WinnerId = r_Players[m_CountTurns % k_NumberOfPlayers].Id;
            }
            else if (r_BoardManager.IsBoardFull(m_CountTurns))
            {
                o_BoardIsFull = true;
                gameOver = true;
            }

            return gameOver;
        }

        public string GetPlayerName(int i_Index)
        {
            return r_Players[i_Index].Name;
        }

        public int GetPlayerScore(int i_Index)
        {
            return r_Players[i_Index].Score;
        }

        public string GetPlayerNameById(int i_Id)
        {
            string winnerName = string.Empty;

            foreach (Player player in r_Players)
            {
                if (player.Id == i_Id)
                {
                    winnerName = player.Name;
                    break;
                }
            }

            return winnerName;
        }
    }
}