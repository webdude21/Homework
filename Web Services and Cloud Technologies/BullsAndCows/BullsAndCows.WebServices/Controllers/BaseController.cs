namespace BullsAndCows.WebServices.Controllers
{
    using System.Web.Http;

    using BullsAndCows.Data;
    using BullsAndCows.Data.Contracts;

    public class BaseController : ApiController
    {
        public BaseController(IBullsAndCowsData bullsAndCowsData)
        {
            this.BullsAndCowsData = bullsAndCowsData;
        }

        public BaseController()
            : this(new BullsAndCowsData())
        {
        }

        protected IBullsAndCowsData BullsAndCowsData { get; set; }
    }
}