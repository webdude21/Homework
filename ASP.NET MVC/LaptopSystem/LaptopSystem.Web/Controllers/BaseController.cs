namespace LaptopSystem.Web.Controllers
{
    using System.Web.Mvc;

    using LaptopSystem.Data;
    using LaptopSystem.Data.Contracts;

    public class BaseController : Controller
    {
        public BaseController(ILaptopSystemData data)
        {
            this.Data = data;
        }

        public BaseController()
            : this(new LaptopSystemData())
        {
        }

        protected ILaptopSystemData Data { get; set; }
    }
}