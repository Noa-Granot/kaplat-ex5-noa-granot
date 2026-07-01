using System.Drawing;
using System.Windows.Forms;

namespace TicTacToeMisereUI
{
    partial class FormGameSettings
    {
        /// <summary>
        /// Required designer variable. 
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected const int k_MinBoardSize = 4;
        protected const int k_MaxBoardSize = 10;
        protected const int k_NumericWidth = 60;
        protected const string k_ComputerPlaceholder = "[Computer]";

        protected Label m_LabelPlayers;
        protected Label m_LabelFirstPlayer;
        protected TextBox m_TextBoxFirstPlayer;
        protected CheckBox m_CheckBoxSecondPlayer;
        protected TextBox m_TextBoxSecondPlayer;
        protected Label m_LabelBoardSize;
        protected Label m_LabelRows;
        protected NumericUpDown m_NumericUpDownRows;
        protected Label m_LabelCols;
        protected NumericUpDown m_NumericUpDownCols;
        protected Button m_ButtonPlay;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "FormGameSettings";

            this.Text = "Game Settings";
            this.Size = new Size(300, 320);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.AutoScaleMode = AutoScaleMode.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            m_LabelPlayers = new Label();
            m_LabelPlayers.Text = "Players:";
            m_LabelPlayers.AutoSize = true;
            m_LabelPlayers.Location = new Point(20, 20);
            this.Controls.Add(m_LabelPlayers);

            m_LabelFirstPlayer = new Label();
            m_LabelFirstPlayer.Text = "Player 1:";
            m_LabelFirstPlayer.AutoSize = true;
            m_LabelFirstPlayer.Location = new Point(30, 55);
            this.Controls.Add(m_LabelFirstPlayer);

            m_TextBoxFirstPlayer = new TextBox();
            m_TextBoxFirstPlayer.Location = new Point(110, 52);
            this.Controls.Add(m_TextBoxFirstPlayer);

            m_CheckBoxSecondPlayer = new CheckBox();
            m_CheckBoxSecondPlayer.Text = "Player 2:";
            m_CheckBoxSecondPlayer.AutoSize = true;
            m_CheckBoxSecondPlayer.Location = new Point(30, 90);
            m_CheckBoxSecondPlayer.Checked = false;
            this.Controls.Add(m_CheckBoxSecondPlayer);

            m_TextBoxSecondPlayer = new TextBox();
            m_TextBoxSecondPlayer.Text = k_ComputerPlaceholder;
            m_TextBoxSecondPlayer.Location = new Point(110, 88);
            m_TextBoxSecondPlayer.Enabled = false;
            this.Controls.Add(m_TextBoxSecondPlayer);

            m_LabelBoardSize = new Label();
            m_LabelBoardSize.Text = "Board Size:";
            m_LabelBoardSize.AutoSize = true;
            m_LabelBoardSize.Location = new Point(20, 130);
            this.Controls.Add(m_LabelBoardSize);

            m_LabelRows = new Label();
            m_LabelRows.Text = "Rows:";
            m_LabelRows.AutoSize = true;
            m_LabelRows.Location = new Point(30, 165);
            this.Controls.Add(m_LabelRows);

            m_NumericUpDownRows = new NumericUpDown();
            m_NumericUpDownRows.Minimum = k_MinBoardSize;
            m_NumericUpDownRows.Maximum = k_MaxBoardSize;
            m_NumericUpDownRows.Value = k_MinBoardSize;
            m_NumericUpDownRows.Location = new Point(80, 162);
            m_NumericUpDownRows.Width = k_NumericWidth;
            this.Controls.Add(m_NumericUpDownRows);

            m_LabelCols = new Label();
            m_LabelCols.Text = "Cols:";
            m_LabelCols.AutoSize = true;
            m_LabelCols.Location = new Point(150, 165);
            this.Controls.Add(m_LabelCols);

            m_NumericUpDownCols = new NumericUpDown();
            m_NumericUpDownCols.Minimum = k_MinBoardSize;
            m_NumericUpDownCols.Maximum = k_MaxBoardSize;
            m_NumericUpDownCols.Value = k_MinBoardSize;
            m_NumericUpDownCols.Location = new Point(200, 162);
            m_NumericUpDownCols.Width = k_NumericWidth;
            this.Controls.Add(m_NumericUpDownCols);

            m_ButtonPlay = new Button();
            m_ButtonPlay.Text = "Play!";
            m_ButtonPlay.Location = new Point(60, 210);
            m_ButtonPlay.Width = 150;
            this.Controls.Add(m_ButtonPlay);
        }

        #endregion
    }
}

