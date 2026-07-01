namespace NotTicTacToeLogic
{
    public abstract class Player
    {
        private static int s_IdGenerator;

        private readonly int r_Id;
        private readonly eSymbols r_Symbol;
        private string m_Name;
        private int m_Score;
        protected Board m_Board;

        public Player()
        {
            r_Id = s_IdGenerator;
            r_Symbol = r_Id % 2 == 0 ? eSymbols.X : eSymbols.O;
            s_IdGenerator++;
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public int Id
        {
            get { return r_Id; }
        }

        public eSymbols Symbol
        {
            get { return r_Symbol; }
        }

        public int Score
        {
            get { return m_Score; }
        }

        public void IncrementScore()
        {
            m_Score++;
        }

        public void SetBoard(Board i_Board)
        {
            m_Board = i_Board;
        }

        public abstract bool TryGetMove(out int o_Row, out int o_Col);
    }
}