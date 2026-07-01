using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NotTicTacToeLogic;

namespace TicTacToeMisereUI
{
    public partial class FormGame : Form
    {
        private const int k_CellSize = 60;
        private const int k_Margin = 10;
        private const int k_ScoreAreaHeight = 30;
        private const int k_ScoreLabelTopSpacing = 5;

        private readonly Game r_Game;
        private readonly int r_BoardSize;
        private Button[,] m_Buttons;
        private Label m_LabelFirstPlayerScore;
        private Label m_LabelSecondPlayerScore;

        public FormGame(int i_BoardSize, string i_FirstPlayerName, string i_SecondPlayerName, bool i_SecondPlayerIsComputer)
        {
            InitializeComponent();
            r_BoardSize = i_BoardSize;
            r_Game = new Game(i_BoardSize, i_SecondPlayerIsComputer, i_FirstPlayerName, i_SecondPlayerName);
            buildBoard();
            r_Game.CellChanged += r_Game_CellChanged;   
        }

        private void r_Game_CellChanged(Game sender)
        {
            int row = sender.LastChangedRow;
            int col = sender.LastChangedCol;
            eSymbols symbol = sender.GetSymbolAt(row, col);

            m_Buttons[row, col].Text = symbol == eSymbols.Empty ? string.Empty : ((char)symbol).ToString();
            m_Buttons[row, col].Enabled = symbol == eSymbols.Empty;
        }

        private void buildBoard()
        {
            this.Text = "TicTacToeMisere";
            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            m_Buttons = new Button[r_BoardSize, r_BoardSize];

            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
                {
                    Button button = new Button();
                    button.Size = new Size(k_CellSize, k_CellSize);
                    button.Location = new Point(k_Margin + col * k_CellSize, k_Margin + row * k_CellSize);
                    button.Click += cellButton_Click;
                    this.Controls.Add(button);
                    m_Buttons[row, col] = button;
                }
            }

            int labelsY = k_Margin + r_BoardSize * k_CellSize + k_ScoreLabelTopSpacing;

            m_LabelFirstPlayerScore = new Label();
            m_LabelFirstPlayerScore.AutoSize = true;
            m_LabelFirstPlayerScore.Location = new Point(k_Margin, labelsY);
            this.Controls.Add(m_LabelFirstPlayerScore);

            m_LabelSecondPlayerScore = new Label();
            m_LabelSecondPlayerScore.AutoSize = true;
            m_LabelSecondPlayerScore.Location = new Point(k_Margin + (r_BoardSize * k_CellSize) / 2, labelsY);
            this.Controls.Add(m_LabelSecondPlayerScore);

            updateScores();

            this.ClientSize = new Size(
                k_Margin * 2 + r_BoardSize * k_CellSize,
                k_Margin * 2 + r_BoardSize * k_CellSize + k_ScoreAreaHeight);
        }

        private void updateScores()
        {
            m_LabelFirstPlayerScore.Text = string.Format("{0}: {1}", r_Game.GetPlayerName(0), r_Game.GetPlayerScore(0));
            m_LabelSecondPlayerScore.Text = string.Format("{0}: {1}", r_Game.GetPlayerName(1), r_Game.GetPlayerScore(1));
        }

        private void getButtonPosition(Button i_Button, out int o_Row, out int o_Col)
        {
            o_Row = -1;
            o_Col = -1;

            for (int row = 0; row < r_BoardSize; row++)
            {
                for (int col = 0; col < r_BoardSize; col++)
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
            bool cellIsOccupied;
            r_Game.TryToPlayTurn(i_Row, i_Col, out cellIsOccupied);
        }

        private void cellButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int row, col;

            getButtonPosition(clickedButton, out row, out col);
            playMove(row, col);

            if (!checkGameOver())
            {
                int computerRow, computerCol;

                if (r_Game.TryGetComputerMove(out computerRow, out computerCol))
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
            bool gameOver = r_Game.IsGameOver(out boardIsFull, out winnerId);

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
            StringBuilder message = new StringBuilder();

            if (i_BoardIsFull)
            {
                title = "A Tie!";
                message.AppendLine("Tie!");
                message.AppendLine("Would you like to play another round?");
            }
            else
            {
                string winnerName = r_Game.GetPlayerNameById(i_WinnerId);
                title = "A Win!";
                message.AppendLine(string.Format("The winner is {0}!", winnerName));
                message.AppendLine("Would you like to play another round?");
            }

            DialogResult answer = MessageBox.Show(message.ToString(), title, MessageBoxButtons.YesNo);

            if (answer == DialogResult.Yes)
            {
                startNewRound();
            }
            else
            {
                this.Close();
            }
        }

        private void startNewRound()
        {
            r_Game.StartNewRound();
            updateScores();
        }
    }
}