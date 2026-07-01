namespace NotTicTacToeLogic
{
    public class HumanPlayer : Player
    {
        public override bool HasCoordinates(out int o_Row, out int o_Col)
        {
            o_Row = -1;
            o_Col = -1;
            return false;
        }
    }
}
