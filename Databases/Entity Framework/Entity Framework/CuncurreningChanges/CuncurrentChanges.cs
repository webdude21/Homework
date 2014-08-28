namespace CuncurreningChanges
{
    using System.Linq;

    using NortwindModel;

    internal class CuncurrentChanges
    {
        private static void Main()
        {
            var firstConnection = new NorthwindEntities();
            var secondConnection = new NorthwindEntities();

            for (var index = 0; index < 5; index++)
            {
                firstConnection.Categories.Add(new Category { CategoryName = "firstConn" + index });
                secondConnection.Categories.Add(new Category { CategoryName = "secondConn" + index });
                firstConnection.SaveChanges();
                secondConnection.SaveChanges();
            }

            var firstEntry = firstConnection.Categories.First(x => x.CategoryName == "firstConn0");
            firstEntry.CategoryName = "changed";

            var sameEntry = secondConnection.Categories.First(x => x.CategoryName == "firstConn0");

            secondConnection.Categories.Remove(sameEntry);
            firstConnection.SaveChanges();
        }
    }
}