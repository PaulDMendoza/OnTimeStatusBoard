using System;
using System.Linq;
using OnTimeApi;

namespace StatusBoard.Models.Visual
{
    public class DataJsonModel
    {
        public DataJsonModel(int userID)
        {
            var context = new UsersContext();
            var userProfile = context.UserProfiles.First(u => u.UserId == userID);

            ServerTimeStamp = DateTime.UtcNow.ToString();

            var api = new OnTime(new Settings(userProfile.OnTimeBaseUrl, WebConfig.OnTimeClientID, WebConfig.OnTimeClientSecret));
            

        }
        
        public string ServerTimeStamp { get; set; }

    }
}