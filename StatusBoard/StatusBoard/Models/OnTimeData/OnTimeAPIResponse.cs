namespace StatusBoard.Models
{
    public class OnTimeAPIResponse<T>
    {
        public OnTimeAPIResponse(T o, int countRequestsToday)
        {
            Object = o;
            CountRequestsToday = countRequestsToday;
        }
        public T Object { get; set; }
        public int CountRequestsToday { get; set; }
    }
}