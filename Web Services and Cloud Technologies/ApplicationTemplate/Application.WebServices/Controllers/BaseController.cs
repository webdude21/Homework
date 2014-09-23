namespace Application.WebServices.Controllers
{
    using System.Web.Http;

    using Application.Data;
    using Application.Data.Contracts;

    public class BaseController : ApiController
    {
        public BaseController(IApplicationData applicationData)
        {
            this.ApplicationData = applicationData;
        }

        public BaseController()
            : this(new ApplicationData())
        {
        }

        protected IApplicationData ApplicationData { get; set; }
    }
}