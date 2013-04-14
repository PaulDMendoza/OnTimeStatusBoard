using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Collections.Concurrent;
using OnTimeApi;
using StatusBoard.Models.OnTimeApiModels;

namespace StatusBoard.Models
{
    public class OnTimeDataRepository
    {
        private static ConcurrentDictionary<int, UserOnTimeData> _usersData = new ConcurrentDictionary<int, UserOnTimeData>(); 
        
        private OnTimeApi.OnTime _api;
        private OnTimeApi.OnTime API
        {
            get
            {
                if (_api == null)
                {
                    var userContext = new UsersContext();
                    var userProfile = userContext.UserProfiles.First(u => u.UserId == _userID);

                    _api = new OnTimeApi.OnTime(new Settings(userProfile.OnTimeBaseUrl, WebConfig.OnTimeClientID, WebConfig.OnTimeClientSecret), userProfile.OnTimeAuthorizationToken);
                }
                return _api;
            }
        }

        private int _userID;
        private UserOnTimeData _userOnTimeData;

        public OnTimeDataRepository(int userID)
        {
            this._userID = userID;

            if (!_usersData.TryGetValue(this._userID, out _userOnTimeData))
            {
                _userOnTimeData = new UserOnTimeData(this._userID);
                while (!_usersData.TryAdd(_userOnTimeData.UserID, _userOnTimeData))
                {
                    Thread.Sleep(10);
                }
            }
        }
        
        public IEnumerable<Defect> MostRecentDefects()
        {
            return CallAPI<Defects>("v1/defects", new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("sort_fields", "created_date_time desc") })
                .Object
                .data
                .Select(s=>MapProperties(s))
                .ToList();
        }

        public T MapProperties<T>(T item)
        {
            foreach (var t in item.GetType().GetProperties())
            {
                if (t.CanWrite)
                {
                    
                }
                if (t.GetValue(item) == null)
                {
                    continue;
                }
                if (t.PropertyType == typeof (Priority))
                {
                    var prioritySmall = (Priority) t.GetValue(item);
                    var matchingPriority = _userOnTimeData.Priorities.FirstOrDefault(p => p.id == prioritySmall.id);
                    if (matchingPriority == null)
                    {
                        _userOnTimeData.Priorities = CallAPI<Priorities>("v1/picklists/priority").Object.data;
                        matchingPriority = _userOnTimeData.Priorities.FirstOrDefault(p => p.id == prioritySmall.id);
                    }
                    t.SetValue(item, matchingPriority);
                }
            }
            return item;
        }
         
        
        private OnTimeAPIResponse<T> CallAPI<T>(string resource, IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            var userContext = new UsersContext();
            var userProfile = userContext.UserProfiles.First(u => u.UserId == _userID);
            if (userProfile.LastRequestDate != DateTime.UtcNow.Date)
            {
                userProfile.LastRequestDate = DateTime.UtcNow.Date;
                userProfile.CountRequestsToday = 0;
            }
            userProfile.CountRequestsToday += 1;

            var api = API;
            try
            {
                var o = api.Get<T>(resource, null);
                var result = new OnTimeAPIResponse<T>(o, userProfile.CountRequestsToday ?? 0);
                return result;
            }
            finally
            {
                userContext.SaveChanges();
            }
        }
    }

    public class UserOnTimeData
    {
        public UserOnTimeData(int userID)
        {
            UserID = userID;
            Priorities = new List<Priority>();
        }
        public int UserID { get; set; }
        public IEnumerable<Priority> Priorities { get; set; } 
    }
}