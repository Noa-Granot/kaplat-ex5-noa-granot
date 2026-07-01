using System;
using System.Drawing;
using System.Windows.Forms;
using NotTicTacToeLogic;

namespace TicTacToeMisereUI
{
    public partial class FormGame : Form
    {
        private Game m_Game;
        private int m_BoardSize;
        private Button[,] m_Buttons;
        private Label m_LabelFirstPlayerScore;
        private Label m_LabelSecondPlayerScore;

        public FormGame(int i_BoardSize, string i_FirstPlayerName, string i_SecondPlayerName, bool i_SecondPlayerIsComputer)
        {
            InitializeComponent();
            m_BoardSize = i_BoardSize;
            m_Game = new Game();
            m_Game.InitializeGame(i_BoardSize, i_SecondPlayerIsComputer);
            m_Game.GetPlayers()[0].Name = i_FirstPlayerName;
            m_Game.GetPlayers()[1].Name = i_SecondPlayerName;
            buildBoard();
        }

        private void buildBoard()
        {
            this.Text = "TicTacToeMisere";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            int cellSize = 60;
            int margin = 10;
            m_Buttons = new Button[m_BoardSize, m_BoardSize];

            for (int row = 0; row < m_BoardSize; row++)
            {
                for (int col = 0; col < m_BoardSize; col++)
                {
                    Button button = new Button();
                    button.Size = new Size(cellSize, cellSize);
                    button.Location = new Point(margin + col * cellSize, margin + row * cellSize);
                    button.Click += cellButton_Click;
                    this.Controls.Add(button);
                    m_Buttons[row, col] = button;
                }
            }

            int labelsY = margin + m_BoardSize * cellSize + 5;

            m_LabelFirstPlayerScore = new Label();
            m_LabelFirstPlayerScore.AutoSize = true;
            m_LabelFirstPlayerScore.Location = new Point(margin, labelsY);
            this.Controls.Add(m_LabelFirstPlayerScore);

            m_LabelSecondPlayerScore = new Label();
            m_LabelSecondPlayerScore.AutoSize = true;
            m_LabelSecondPlayerScore.Location = new Point(margin + (m_BoardSize * cellSize) / 2, labelsY);
            this.Controls.Add(m_LabelSecondPlayerScore);

            updateScores();

            this.ClientSize = new Size(margin * 2 + m_BoardSize * cellSize, margin * 2 + m_BoardSize * cellSize + 30);
        }

        private void updateScores()
        {
            Player[] players = m_Game.GetPlayers();
            m_LabelFirstPlayerScore.Text = string.Format("{0}: {1}", players[0].Name, players[0].GetScore());
            m_LabelSecondPlayerScore.Text = string.Format("{0}: {1}", players[1].Name, players[1].GetScore());
        }

        private void getButtonPosition(Button i_Button, out int o_Row, out int o_Col)
        {
            o_Row = -1;
            o_Col = -1;

            for (int row = 0; row < m_BoardSize; row++)
            {
                for (int col = 0; col < m_BoardSize; col++)
                {
                    if (m_Buttons[row, col] == i_Button)
                    {
                        o_Row = row;
                        o_Col = col;
                        break;
                    }
                }
            }
        }

        private void playMove(int i_Row, int i_Col)
        {
            eSymbols symbol = m_Game.GetCurrentPlayer().GetSymbol();
            bool cellIsOccupied;

            if (m_Game.TryToPlayTurn(i_Row, i_Col, out cellIsOccupied))
            {
                m_Buttons[i_Row, i_Col].Text = ((char)symbol).ToString();
                m_Buttons[i_Row, i_Col].Enabled = false;
            }
        }

        private void cellButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int row, col;

            getButtonPosition(clickedButton, out row, out col);
            playMove(row, col);

            if (!checkGameOver())
            {
                int computerRow, computerCol;

                if (m_Game.GetCurrentPlayer().HasCoordinates(out computerRow, out computerCol))
                {
                    playMove(computerRow, computerCol);
                    checkGameOver();
                }
            }
        }

        private bool checkGameOver()
        {
            bool boardIsFull;
            int winnerId;
            bool gameOver = m_Game.IsGameOver(out boardIsFull, out winnerId);

            if (gameOver)
            {
                updateScores();
                handleEndOfRound(boardIsFull, winnerId);
            }

            return gameOver;
        }

        private void handleEndOfRound(bool i_BoardIsFull, int i_WinnerId)
        {
            string title;
            string message;

            if (i_BoardIsFull)
            {
                title = "A Tie!";
                message = "Tie!\nWould you like to play another round?";
            }
            else
            {
                string winnerName = getPlayerNameById(i_WinnerId);
                title = "A Win!";
                message = string.Format("The winner is {0}!\nWould you like to play another round?", winnerName);
            }

            DialogResult answer = MessageBox.Show(message, title, MessageBoxButtons.YesNo);

            if (answer == DialogResult.Yes)
            {
                startNewRound();
            }
            else
            {
                this.Close();
            }
        }

        private string getPlayerNameById(int i_Id)
        {
            Player[] players = m_Game.GetPlayers();
            string name;

            if (players[0].GetId() == i_Id)
            {
                name = players[0].Name;
            }
            else
            {
                name = players[1].Name;
            }

            return name;
        }

        private void startNewRound()
        {
            m_Game.ResetGame();

            for (int row = 0; row < m_BoardSize; row++)
            {
                for (int col = 0; col < m_BoardSize; col++)
                {
                    m_Buttons[row, col].Text = "";
                    m_Buttons[row, col].Enabled = true;
                }
            }

            updateScores();
        }
    }
}