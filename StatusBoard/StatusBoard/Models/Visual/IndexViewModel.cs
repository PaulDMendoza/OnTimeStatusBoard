using System;
using System.Collections.Generic;
using System.Linq;
using OnTimeApi;
using StatusBoard.Controllers;
using StatusBoard.Models.OnTimeApiModels;

namespace StatusBoard.Models.Visual
{
    public class IndexViewModel
    {
        public VisualController.ItemType ItemType { get; set; }

        public string SingularItemName
        {
            get
            {
                if (this.ItemType == VisualController.ItemType.defects)
                    return "Defect";
                else if (this.ItemType == VisualController.ItemType.features)
                    return "Feature";
                else
                    throw new NotImplementedException("No SingularItemName for " + this.ItemType);
            }
        }

        public string PluralItemsName
        {
            get
            {
                if (this.ItemType == VisualController.ItemType.defects)
                    return "Defects";
                else if (this.ItemType == VisualController.ItemType.features)
                    return "Features";
                else
                    throw new NotImplementedException("No PluralItemsName for " + this.ItemType);
            }
        }

        public int RefreshRate { get; protected set; }

        public bool ShowFeatures { get; set; }
        public bool ShowDefects { get; set; }

        public IndexViewModel(int userID, VisualController.ItemType? type)
        {
            var context = new UsersContext();
            var userProfile = context.UserProfiles.First(u => u.UserId == userID);

            ShowFeatures = userProfile.ShowFeatures;
            ShowDefects = userProfile.ShowDefects;

            if (type == null)
            {
                if (ShowDefects)
                    type = VisualController.ItemType.defects;
                else
                    type = VisualController.ItemType.features;
            }

            ItemType = type.Value;

            RefreshRate = userProfile.RefreshRate;

            ServerTimeStamp = DateTime.UtcNow.ToString();

            var dataRepository = new OnTimeDataRepository(userID);
            RecentDefects = dataRepository.ItemsOfType(ItemType);
        }

        public string ServerTimeStamp { get; set; }
        public IEnumerable<DefectOrFeature> RecentDefects { get; set; }
    }
}