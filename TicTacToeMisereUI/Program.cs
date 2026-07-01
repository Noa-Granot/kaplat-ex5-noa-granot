using System;
using System.Windows.Forms;

namespace TicTacToeMisereUI
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormGameSettings settings = new FormGameSettings();
            if (settings.ShowDialog() == DialogResult.OK)
            {
                FormGame gameForm = new FormGame(
                    settings.BoardSize,
                    settings.FirstPlayerName,
                    settings.SecondPlayerName,
                    settings.IsSecondPlayerComputer);
                gameForm.ShowDialog();
            }
        }
    }
}