using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FPTJobMatch.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FPTJobMatch.Models;

namespace FPTJobMatch.Controllers
{
    public class CVsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CVsController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public CVsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CVs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CV.ToListAsync());
        }

        // GET: CVs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cV = await _context.CV
                .FirstOrDefaultAsync(m => m.CVID == id);
            if (cV == null)
            {
                return NotFound();
            }

            return View(cV);
        }

        // GET: CVs/Create
        [Authorize(Roles = "Jobseeker")]

        public IActionResult Create()
        {
            return View();
        }

        // POST: CVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CV product, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                //check if a new image file is uploaded or not
                if (Image != null && Image.Length > 0)
                {
                    //set image file name
                    //Note: should add a prefix to make sure the file name is unique
                    var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(Image.FileName);
                    //set image file location
                    //Note: should create a subfolder named "images" in "wwwroot" to store all images
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //copy (upload) image file from orignal location to project folder
                        Image.CopyTo(stream);
                    }

                    //set image file name for book cover
                    product.file = "/pdf/" + fileName;
                }
                _context.CV.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: CVs/Edit/5
        [Authorize(Roles = "Jobseeker")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cV = await _context.CV.FindAsync(id);
            if (cV == null)
            {
                return NotFound();
            }
            return View(cV);
        }

        // POST: CVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Price")] CV product)
        {
            if (id != product.CVID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CVExists(product.CVID))
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
            return View(product);
        }

        // GET: CVs/Delete/5
        [Authorize(Roles = "Jobseeker")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cV = await _context.CV
                .FirstOrDefaultAsync(m => m.CVID == id);
            if (cV == null)
            {
                return NotFound();
            }

            return View(cV);
        }

        // POST: CVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cV = await _context.CV.FindAsync(id);
            _context.CV.Remove(cV);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CVExists(int id)
        {
            return _context.CV.Any(e => e.CVID == id);
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

    }
}
