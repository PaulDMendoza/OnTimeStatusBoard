﻿using System;
using System.Collections.Generic;
using System.Linq;
using OnTimeApi;
using StatusBoard.Controllers;
using StatusBoard.Models.OnTimeApiModels;

namespace StatusBoard.Models.Visual
{
    public class DataJsonModel
    {
        public DataJsonModel(int userID, VisualController.ItemType type)
        {
            var context = new UsersContext();
            var userProfile = context.UserProfiles.First(u => u.UserId == userID);

            ServerTimeStamp = DateTime.UtcNow.ToString();
            
            var dataRepository = new OnTimeDataRepository(userID);
            RecentDefects = dataRepository.ItemsOfType(type);
        }
        
        public string ServerTimeStamp { get; set; }
        public IEnumerable<DefectOrFeature> RecentDefects { get; set; }
        
        
    }
}