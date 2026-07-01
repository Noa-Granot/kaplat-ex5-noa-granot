namespace NotTicTacToeLogic
{
    public abstract class Player
    {
        private int m_Id;
        private string m_Name;
        private int m_Score = 0;
        protected Board m_Board = null;
        private eSymbols m_Symbol;
        private static int s_IdGenerator = 0;
        public Player()
        {
            m_Id = s_IdGenerator;
            m_Symbol = (eSymbols)(s_IdGenerator % 2 == 0 ? eSymbols.X : eSymbols.O);
            s_IdGenerator++;
        }
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public void ResetScore()
        {
            m_Score = 0;
        }
        public int GetId()
        {
            return m_Id;
        }
        public eSymbols GetSymbol()
        {
            return m_Symbol;
        }
        public int GetScore()
        {
            return m_Score;
        }
        public void IncrementScore()
        {
            m_Score++;
        }
        public void SetBoard(Board i_Board)
        {
            m_Board = i_Board;
        }
        public virtual bool HasCoordinates(out int o_Row, out int o_Col)
        {
            o_Row = -1;
            o_Col = -1;
            return false;
        }
    }
}