namespace TicTacToe.Web.Controllers
{
    using System.Web.Http;

    using TicTacToe.Data;

    [Authorize]
    public abstract class BaseApiController : ApiController
    {
        protected ITicTacToeData data;

        protected BaseApiController(ITicTacToeData data)
        {
            this.data = data;
        }
    }
}