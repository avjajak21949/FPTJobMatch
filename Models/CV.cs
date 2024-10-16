using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FPTJobMatch.Models;
using Microsoft.AspNetCore.Identity;

public class CV
{
	public int CVID { get; set; }
	[Required]
	public string file { get; set; }
    public string ApplicantId { get; set; } // Id của người tìm việc nộp CV
    public IdentityUser Applicant { get; set; }
    public bool? IsApproved { get; set; } // null = chưa duyệt, true = chấp nhận, false = từ chối
    public ICollection<JobCV> JobCV { get; set; }
}
