using System;

namespace StatusBoard.Models.OnTimeApiModels
{
    public class MiniDefect
    {
        public int id { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public WorkflowStep workflow_step { get; set; }
        public Priority priority { get; set; }
        public OnTimeUser assigned_to { get; set; }
        public DateTime? created_date_time { get; set; }
        public DateTime? last_updated_date_time { get; set; }
        public Status status { get; set; }
    }
}