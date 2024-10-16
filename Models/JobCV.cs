namespace FPTJobMatch.Models
{
    public class JobCV
    {
        public int JobCVID { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public int CVID { get; set; }
        public CV CV { get; set; }


    }
}
