namespace Application.WCF
{
    using System.Collections.Generic;
    using System.Linq;

    using Application.Data;
    using Application.Data.Contracts;
    using Application.WCF.Models;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Users" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Users.svc or Users.svc.cs at the Solution Explorer and start debugging.
    public class Users : IUsers
    {
        private const int PageSize = 10;

        private readonly IBullsAndCowsData bullsAndCowsData;

        public Users(IBullsAndCowsData bullsAndCowsData)
        {
            this.bullsAndCowsData = bullsAndCowsData;
        }

        public Users()
            : this(new BullsAndCowsData())
        {
        }


        public IEnumerable<UserModel> GetUsers()
        {
            var result = this.bullsAndCowsData.Users.All().OrderBy(u => u.UserName).Skip(0 * PageSize).Take(PageSize);
            var resultList = new List<UserModel>();

            foreach (var applicationUser in result)
            {
                resultList.Add(new UserModel(applicationUser));
            }

            return resultList.ToList();
        }
    }
}