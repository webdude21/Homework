namespace Application.WebServices.Controllers
{
    using System.Web.Http;

    using Application.Data;
    using Application.Data.Contracts;

    public class BaseController : ApiController
    {
        private IApplicationData applicationData;

        public BaseController(IApplicationData applicationData)
        {
            this.applicationData = applicationData;
        }

        public BaseController()
            : this(new ApplicationData())
        {
        }
    }
}