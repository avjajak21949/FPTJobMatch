using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace FPTJobMatch.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(250, 50000)]
        public int Salary {  get; set; }
        [Required]
        public string Place {  get; set; }
        [Required]
        public string Time {  get; set; }
        public int CategoryID {  get; set; }
        public Category Category { get; set; }
        public ICollection<JobCV> JobCV { get; set; }
    }
}
