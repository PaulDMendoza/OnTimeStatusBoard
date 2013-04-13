using System;

namespace StatusBoard.Models.OnTimeApiModels
{
    public class Release
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool can_modify { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? due_date { get; set; }
        public DateTime? velocity_start_date { get; set; }
        public string release_notes { get; set; }
        public int status { get; set; }
        public bool is_active { get; set; }
        public int release_type { get; set; }
        public Release[] children { get; set; }
    }
}