namespace MyBestAPI2.Models
{
    public class WorkerApiResponse
    {
        public string Status { get; set; }
        public List<Worker> Data { get; set; }
        public string Message { get; set; }
    }
}
