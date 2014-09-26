namespace BullsAndCows.WebServices.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using BullsAndCows.Data.Contracts;
    using BullsAndCows.WebServices.DataModels;

    public class ScoresController : BaseController
    {
        private const int PageSize = 10;

        public ScoresController(IBullsAndCowsData bullsAndCowsData)
            : base(bullsAndCowsData)
        {
        }

        public ScoresController()
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.All(0);
        }

        [HttpGet]
        public IHttpActionResult All(int page)
        {
            var result = this.BullsAndCowsData.Users.All();
            var resultList = new List<ScoreModel>();

            foreach (var applicationUser in result)
            {
                resultList.Add(new ScoreModel(applicationUser));
            }

            return this.Ok(resultList.OrderBy(u => u.Rank).ThenBy(u => u.Username).Skip(page * PageSize).Take(PageSize));
        }
    }
}