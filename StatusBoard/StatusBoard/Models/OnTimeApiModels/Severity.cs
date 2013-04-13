namespace StatusBoard.Models.OnTimeApiModels
{
    public class Severity
    {
        public int id { get; set; }
        public int order { get; set; }
        public string name { get; set; }
        /// <summary>
        /// Only returned from v1/picklists/severity. Example value: "318d14". Notice the missing # mark for the hex value.
        /// </summary>
        public string color { get; set; }
    }
}