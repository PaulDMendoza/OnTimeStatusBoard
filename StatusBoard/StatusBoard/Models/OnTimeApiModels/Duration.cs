namespace StatusBoard.Models.OnTimeApiModels
{
    public class Duration
    {
        public decimal duration_minutes { get; set; }
        public string duration_text { get; set; }
        public decimal aggregate_duration_minutes { get; set; }
    }
}