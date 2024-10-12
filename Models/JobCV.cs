namespace FPTJobMatch.Models
{
    public class JobCV
    {
        public int JobCVID { get; set; }
        public Job Job { get; set; }
        public CV CV { get; set; }
    }
}
