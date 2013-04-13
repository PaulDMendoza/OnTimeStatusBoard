using System;

namespace StatusBoard.Models.OnTimeApiModels
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? due_date { get; set; }
        public bool is_active { get; set; }
        public Project[] children { get; set; }
    }
    
}