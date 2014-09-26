namespace TicTacToe.GameLogic
{
    public interface IGameResultValidator
    {
        GameResult GetResult(string board);
    }
}