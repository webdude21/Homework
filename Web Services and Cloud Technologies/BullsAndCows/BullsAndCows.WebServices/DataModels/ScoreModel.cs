namespace BullsAndCows.WebServices.DataModels
{
    using BullsAndCows.Models;

    public class ScoreModel
    {
        public ScoreModel(ApplicationUser user)
        {
            this.Rank = 100 * user.UserWinsCount + 15 * user.UserLossesCount;
            this.Username = user.UserName;
        }

        public ScoreModel()
        {
            
        }

        public string Username { get; set; }

        public int Rank { get; set; }
    }
}