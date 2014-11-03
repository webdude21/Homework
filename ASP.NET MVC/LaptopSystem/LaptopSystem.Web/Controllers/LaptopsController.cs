namespace LaptopSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using LaptopSystem.Web.Models;

    public class LaptopController : BaseController
    {
        public ActionResult Details(int id)
        {
            var viewLaptop =
                this.Data.Laptops.All()
                    .Where(x => x.Id == id)
                    .Select(laptop => new LaptopDetailsViewModel
                            {
                                AdditionalParts = laptop.AdditionalParts,
                                Manufacturer = laptop.Manufacturer.Name,
                                Model = laptop.Model,
                                Price = laptop.Price,
                                Weight = laptop.Weight,
                                Description = laptop.Description,
                                ImageUrl = laptop.ImageUrl,
                                HardDriveSize = laptop.HardDriveSize,
                                Monitor = laptop.Monitor,
                                RamSize = laptop.RamSize,
                                Comments = laptop.Comments.Select(comment =>
                                        new CommentViewModel
                                            {
                                                AuthorUserName =
                                                    comment.Author.UserName,
                                                Content = comment.Content
                                            })
                            })
                    .FirstOrDefault();

            return this.View(viewLaptop);
        }
    }
}