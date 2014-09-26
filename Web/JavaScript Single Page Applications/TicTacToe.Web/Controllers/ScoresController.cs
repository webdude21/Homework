namespace TicTacToe.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using TicTacToe.Data;
    using TicTacToe.GameLogic;
    using TicTacToe.Models;
    using TicTacToe.Web.Infrastructure;

    public class ScoresController : BaseApiController
    {
        private IUserIdProvider userIdProvider;

        public ScoresController(
            ITicTacToeData data, 
            IGameResultValidator resultValidator, 
            IUserIdProvider userIdProvider)
            : base(data)
        {
            this.userIdProvider = userIdProvider;
        }

        // GET: api/Scores
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            var scores =
                this.data.Users.All()
                    .OrderByDescending(CalcRank)
                    .Select(u => new { User = u.Email, Score = CalcRank(u), u.Wins, u.Losses });

            return this.Ok(scores);
        }

        private static int CalcRank(User user)
        {
            return 100 * user.Wins + 15 * user.Losses;
        }
    }
}