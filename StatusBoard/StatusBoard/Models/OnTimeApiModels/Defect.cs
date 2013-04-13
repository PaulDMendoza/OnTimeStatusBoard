using System;

namespace StatusBoard.Models.OnTimeApiModels
{
    public class Defect
    {
        public int id { get; set; }
        public string number { get; set; }
        public string name { get; set; }
        public WorkflowStep workflow_step { get; set; }
        public Priority priority { get; set; }
        public OnTimeUser assigned_to { get; set; }
        public Project project { get; set; }
        public DateTime? reported_date { get; set; }
        public string build_number { get; set; }
        public DateTime? completion_date { get; set; }
        public string build_number_of_fix { get; set; }
        public Severity severity { get; set; }
        public Status status { get; set; }
        public OnTimeUser reported_by { get; set; }
        public Duration estimated_duration { get; set; }
        public Duration actual_duration { get; set;  }
        public decimal percent_complete { get; set; }
        public bool publicly_viewable { get; set; }
        public CustomerContact reported_by_customer_contact { get; set; }
        public OnTimeUser created_by { get; set; }
        public DateTime? created_date_time { get; set; }
        public OnTimeUser last_updated_by { get; set; }
        public DateTime? last_updated_date_time { get; set; }
        public bool archived { get; set; }
        public Duration remaining_duration { get; set; }
        public Release release { get; set; }
        public Vote vote { get; set; }
        public int? is_ranked { get; set; }
        public ParentProject parent_project { get; set; }
        public Customer customer { get; set; }
    }
}