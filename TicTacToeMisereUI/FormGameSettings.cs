using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToeMisereUI
{
    public partial class FormGameSettings : Form
    {
        public FormGameSettings()
        {
            InitializeComponent();
            addEvents();
        }

        private void addEvents()
        {
            m_CheckBoxSecondPlayer.CheckedChanged += checkBoxSecondPlayer_CheckedChanged;
            m_NumericUpDownRows.ValueChanged += numericUpDownRows_ValueChanged;
            m_NumericUpDownCols.ValueChanged += numericUpDownCols_ValueChanged;
            m_ButtonPlay.Click += buttonPlay_Click;
        }

        private void checkBoxSecondPlayer_CheckedChanged(object sender, EventArgs e)
        {
            m_TextBoxSecondPlayer.Enabled = m_CheckBoxSecondPlayer.Checked;

            if (m_CheckBoxSecondPlayer.Checked)
            {
                m_TextBoxSecondPlayer.Text = string.Empty;
            }
            else
            {
                m_TextBoxSecondPlayer.Text = k_ComputerPlaceholder;
            }
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            m_NumericUpDownCols.Value = m_NumericUpDownRows.Value;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            m_NumericUpDownRows.Value = m_NumericUpDownCols.Value;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public int BoardSize
        {
            get { return (int)m_NumericUpDownRows.Value; }
        }

        public bool IsSecondPlayerComputer
        {
            get { return !m_CheckBoxSecondPlayer.Checked; }
        }

        public string FirstPlayerName
        {
            get
            {
                string name;

                if (string.IsNullOrEmpty(m_TextBoxFirstPlayer.Text))
                {
                    name = "Player 1";
                }
                else
                {
                    name = m_TextBoxFirstPlayer.Text;
                }

                return name;
            }
        }

        public string SecondPlayerName
        {
            get
            {
                string name;

                if (!m_CheckBoxSecondPlayer.Checked)
                {
                    name = "Computer";
                }
                else if (string.IsNullOrEmpty(m_TextBoxSecondPlayer.Text))
                {
                    name = "Player 2";
                }
                else
                {
                    name = m_TextBoxSecondPlayer.Text;
                }

                return name;
            }
        }
    }
}