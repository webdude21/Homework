namespace Application.WebServices.Controllers
{
    using System.Web.Http;

    using Application.Data;
    using Application.Data.Contracts;

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