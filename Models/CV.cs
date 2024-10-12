using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FPTJobMatch.Models;

public class CV
{
	public int CVID { get; set; }
	[Required]
	public string file { get; set; }
	public ICollection<JobCV> JobCV { get; set; }
}
