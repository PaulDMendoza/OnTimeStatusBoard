namespace StatusBoard.Models.OnTimeApiModels
{
    public class Priority
    {
        public int id { get; set; }
        public int order { get; set; }
        public string name { get; set; }

        /// <summary>
        /// Only returned from v1/picklists/priority. Example value: "318d14". Notice the missing # mark for the hex value.
        /// </summary>
        public string color { get; set; }
    }
}