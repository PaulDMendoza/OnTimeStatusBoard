using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StatusBoard.Models.Account
{
    public class ManageDisplaySettingsViewModel
    {
        public IEnumerable<SelectListItem> RefreshRates
        {
            get
            {
                var items = new Dictionary<int, string>
                    {
                        { 60, "1 Minute (Estimated 3000 API Requests Per Day)" },
                        { 120, "2 Minutes (Estimated 1500 API Requests Per Day)" },
                        { 180, "3 Minutes (Estimated 1000 API Requests Per Day)" },
                        { 300, "5 Minutes (Estimated 600 API Requests Per Day)" },
                        { 600, "10 Minutes (Estimated 300 API Requests Per Day)" }
                    };

                var sItems = new List<SelectListItem>();
                foreach (var item in items)
                {
                    var s = new SelectListItem();
                    s.Text = item.Value;
                    s.Value = item.Key.ToString();
                    s.Selected = User.RefreshRate == item.Key;
                    sItems.Add(s);
                }
                return sItems;
            }
        }

        public UserProfile User { get; set; }

        public ManageDisplaySettingsViewModel(UserProfile user)
        {
            User = user;
        }
    }
}