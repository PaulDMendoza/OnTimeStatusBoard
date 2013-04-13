using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatusBoard.Models.OnTimeApiModels
{
    public class FullOnTimeUser
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string login_id { get; set; }
        public string windows_id { get; set; }
        public string use_windows_auth { get; set; }
        public string built_in_account { get; set; }
        public bool is_active { get; set; }
        public bool is_locked { get; set; }
        public int enterprise_connection_type { get; set; }
        public DateTime? last_login_date_time { get; set; }
        public bool has_read_upgrade_message { get; set; }
        public int failed_logins { get; set; }
        public string git_hub_user_id { get; set; }
        public DateTime? created_date_time { get; set; }
    }
}