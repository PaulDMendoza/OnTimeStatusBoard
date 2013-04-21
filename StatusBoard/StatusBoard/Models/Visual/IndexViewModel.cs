﻿using System;
using System.Collections.Generic;
using System.Linq;
using OnTimeApi;
using StatusBoard.Models.OnTimeApiModels;

namespace StatusBoard.Models.Visual
{
    public class IndexViewModel
    {
        public IndexViewModel(int userID)
        {
            var context = new UsersContext();
            var userProfile = context.UserProfiles.First(u => u.UserId == userID);

            ServerTimeStamp = DateTime.UtcNow.ToString();
            
            var dataRepository = new OnTimeDataRepository(userID);
            RecentDefects = dataRepository.Defects();
        }
        
        public string ServerTimeStamp { get; set; }
        public IEnumerable<Defect> RecentDefects { get; set; }
    }
}