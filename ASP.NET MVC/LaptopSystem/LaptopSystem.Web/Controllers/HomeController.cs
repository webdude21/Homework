namespace LaptopSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;

    using LaptopSystem.Web.Models;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            const string Homepagelaptops = "HomePageLaptops";

            if (this.HttpContext.Cache[Homepagelaptops] == null)
            {
                var listOfLaptops =
                                this.Data.Laptops.All()
                                .OrderByDescending(laptop => laptop.Votes.Count)
                                .Take(6)
                                .Select(laptop =>
                                   new LaptopViewModel
                                   {
                                       Id = laptop.Id,
                                       Model = laptop.Model,
                                       Price = laptop.Price,
                                       Manufacturer = laptop.Manufacturer.Name,
                                       ImageUrl = laptop.ImageUrl
                                   }).ToList();

                this.HttpContext.Cache.Add(Homepagelaptops, listOfLaptops, null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Default, null);
            }

            var cachedLaptops = this.HttpContext.Cache[Homepagelaptops];
            return this.View(cachedLaptops);
        }
    }
}