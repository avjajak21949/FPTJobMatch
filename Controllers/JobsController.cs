using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FPTJobMatch.Data;
using FPTJobMatch.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace FPTJobMatch.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public JobsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            // Only show jobs that have been approved
            var approvedJobs = _context.Job.ToList();
            return View(approvedJobs);
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .Include(j => j.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        [Authorize(Roles = "Employer")]
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Category, "Id", "Name");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Salary,Place,Time,CategoryID")] Job job)
        {
            var currentUser = await _userManager.GetUserAsync(User); // Lấy user hiện tại đang đăng nhập
            job.EmployerId = currentUser.Id; // Gán EmployerId là ID của user hiện tại
            if (ModelState.IsValid)
            {
                job.IsApproved = false;
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Category, "Id", "Name", job.CategoryID);
            return View(job);
        }

        // GET: Jobs/Edit/5
        [Authorize(Roles = "Employer")]

        public async Task<IActionResult> Edit(int? id)
        {
            var job = await _context.Job.FindAsync(id);
            var currentUser = await _userManager.GetUserAsync(User); // Lấy user hiện tại
            if (job.EmployerId != currentUser.Id)
            {
                return Unauthorized(); // Nếu công việc này không thuộc về user hiện tại, trả về lỗi 403
            }
            else if (job == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Category, "Id", "Name", job.CategoryID);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Salary,Place,Time,CategoryID")] Job job)
        {
            var currentUser = await _userManager.GetUserAsync(User); // Lấy user hiện tại
            if (job.EmployerId != currentUser.Id)
            {
                return Unauthorized(); // Nếu công việc này không thuộc về user hiện tại, trả về lỗi 403
            }
            if (id != job.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Category, "Id", "Name", job.CategoryID);
            return View(job);
        }

        // GET: Jobs/Delete/5
        [Authorize(Roles = "Employer")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .Include(j => j.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            var currentUser = await _userManager.GetUserAsync(User);

            if (job.EmployerId != currentUser.Id)
            {
                return Unauthorized(); // Kiểm tra quyền sở hữu, nếu không đúng thì từ chối truy cập
            }
            else if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Job.FindAsync(id);
            _context.Job.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> MyJobs()
        {
            var currentUser = await _userManager.GetUserAsync(User); // Lấy user hiện tại
            var jobs = await _context.Job
                                .Where(j => j.EmployerId == currentUser.Id) // Chỉ lấy các công việc do user này đăng
                                .ToListAsync();
            return View(jobs);
        }
        private bool JobExists(int id)
        {
            return _context.Job.Any(e => e.Id == id);
        }

        [Authorize(Roles = "Adminstrator")]
        // Approve a job
        [HttpPost]
        public async Task<IActionResult> ApproveJob(int jobId)
        {
            var job = await _context.Job.FindAsync(jobId);
            if (job != null)
            {
                job.IsApproved = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("PendingJobs");
        }

        [Authorize(Roles = "Adminstrator")]
        // Reject a job (delete it)
        [HttpPost]
        public async Task<IActionResult> RejectJob(int jobId)
        {
            var job = await _context.Job.FindAsync(jobId);
            if (job != null)
            {
                _context.Job.Remove(job);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("PendingJobs");
        }
        [Authorize(Roles = "Jobseeker")]
        public async Task<IActionResult> Apply(int jobId, string cvFile)
        {
            var userId = _userManager.GetUserId(User); // Lấy Id của ứng viên đang đăng nhập

            var cv = new CV
            {
                file = cvFile,
                ApplicantId = userId, // Gắn CV với Jobseeker đang apply
            };

            var jobCV = new JobCV
            {
                JobCVID = jobId,  // Gắn CV với Job
                CV = cv
            };

            _context.JobCV.Add(jobCV); // Thêm vào bảng trung gian JobCV
            await _context.SaveChangesAsync();

            return RedirectToAction("JobDetails", new { id = jobId });
        }

        [HttpPost]
        public async Task<IActionResult> ApplyJob(IFormFile uploadedFile, int jobId)
        {
            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(uploadedFile.FileName);

                // Lưu file vào thư mục uploads
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(stream);
                }

                // Tạo CV mới và lưu vào database
                var cv = new CV
                {
                    file = uploadedFile.FileName,
                    ApplicantId = currentUser.Id
                };

                _context.Add(cv);
                await _context.SaveChangesAsync();

                // Tạo liên kết giữa công việc và CV
                var jobCV = new JobCV
                {
                    JobId = jobId,
                    CVID = cv.CVID
                };

                _context.Add(jobCV);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}