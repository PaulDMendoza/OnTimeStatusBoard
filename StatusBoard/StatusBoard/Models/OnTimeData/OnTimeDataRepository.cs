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
        
        public IEnumerable<MiniDefect> Defects()
        {
            var defects = new List<MiniDefect>();

            int itemsRemaining = int.MaxValue;
            int page_size = 1000;
            
            for (int page = 0; itemsRemaining > page_size && page < 4; page++)
	        {	
	            var response = CallAPI<Defects>("v1/defects", new Dictionary<string, object>()
                {
                    {"sort_fields", "created_date_time desc" },
                    {"page_size", page_size },
                    {"page", page},
                    {"columns", "id,number,name,workflow_step,priority,assigned_to,created_date_time,last_updated_date_time,status" }
                });
                
                defects.AddRange(response.Object.data.Select(d=>MapProperties(d)));

	            page_size = response.Object.metadata.page_size;

		        itemsRemaining = response.Object.metadata.total_count - (page * page_size);
	        }
            
            return defects;
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
                if (t.PropertyType == typeof(Priority))
                {
                    var prioritySmall = (Priority)t.GetValue(item);
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


        private OnTimeAPIResponse<T> CallAPI<T>(string resource, IEnumerable<KeyValuePair<string, object>> parameters = null)
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
                var o = api.Get<T>(resource, parameters);
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