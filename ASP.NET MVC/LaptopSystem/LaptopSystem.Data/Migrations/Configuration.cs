namespace LaptopSystem.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using LaptopSystem.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<LaptopSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LaptopSystemDbContext context)
        {
            if (context.Laptops.Any())
            {
                return;
            }

            var kiro = new ApplicationUser { UserName = "Kiro" };
            var comments = new List<Comment>();
            var votes = new List<Vote>();

            for (var i = 0; i < 10; i++)
            {
                comments.Add(new Comment { Author = kiro, Content = "Ebasimu i qkia laptop" });

                votes.Add(new Vote { Author = kiro, });
            }

            var hp = new Manufacturer { Name = "HP" };
            var asus = new Manufacturer { Name = "Asus" };
            var lenovo = new Manufacturer { Name = "Lenovo" };
            var acer = new Manufacturer { Name = "Acer" };

            context.Laptops.Add(
                new Laptop
                    {
                        Manufacturer = hp, 
                        Model = "Elitebook 8440p", 
                        Price = 2000, 
                        Description = "Rugged metal body, stylish look, build to impress ...", 
                        HardDriveSize = 250, 
                        RamSize = 8, 
                        ImageUrl = "http://static.productreview.com.au/pr.products/201309111108268146_2.jpg", 
                        Monitor = 14, 
                        Weight = 2.4, 
                        Comments = comments, 
                        Votes = votes
                    });

            context.Laptops.Add(
                new Laptop
                    {
                        Manufacturer = asus, 
                        Model = "Zenbook UX51V", 
                        Price = 1800, 
                        Description =
                            "We’ve always been fans of the brand, but this year we were particularly impressed with ASUS’ risky-but-innovative designs", 
                        HardDriveSize = 250, 
                        RamSize = 8, 
                        ImageUrl =
                            "http://blog.laptopmag.com/wpress/wp-content/uploads/2013/11/Asus-N550J-G01_673433.jpg", 
                        Monitor = 15.4, 
                        Weight = 2.7, 
                    });

            context.Laptops.Add(
                new Laptop
                    {
                        Manufacturer = lenovo, 
                        Model = "ThinkPad T440s", 
                        Price = 2200, 
                        Description =
                            "Lenovo's ThinkPad T Series laptops have a legendary reputation amongst business users or anyone who needs to get serious work done. The 14-inch ThinkPad T440s continues this rich tradition", 
                        HardDriveSize = 1000, 
                        RamSize = 8, 
                        ImageUrl =
                            "http://cdn.laptopmag.com/images/uploads/ppress/44547/lenovo-thinkpad-t440s-g04.jpg", 
                        Monitor = 14, 
                        Weight = 2.1, 
                    });

            context.Laptops.Add(
                new Laptop
                    {
                        Manufacturer = acer, 
                        Model = "TravelMate P645", 
                        Price = 1500, 
                        Description = "Acer's flagship business laptop", 
                        HardDriveSize = 1000, 
                        RamSize = 8, 
                        ImageUrl = "http://laptop.bg/system/images/35690/normal/TravelMate_P645.jpg?1395305993", 
                        Monitor = 14, 
                        Weight = 2.3, 
                    });

            context.SaveChanges();
        }
    }
}