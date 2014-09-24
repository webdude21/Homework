namespace Application.WCF.Models
{
    using Application.Models;

    public class UserModel
    {
        public UserModel(ApplicationUser applicationUser)
        {
            this.Id = applicationUser.Id;
            this.Username = applicationUser.UserName;
        }

        public string Id { get; set; }

        public string Username { get; set; }
    }
}