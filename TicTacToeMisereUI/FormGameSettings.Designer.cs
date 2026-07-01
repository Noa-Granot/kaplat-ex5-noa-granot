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
        }

        #endregion
    }
}

