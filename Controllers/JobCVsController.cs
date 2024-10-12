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

namespace FPTJobMatch.Controllers
{
    public class JobCVsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobCVsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobCVs
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobCV.ToListAsync());
        }

        // GET: JobCVs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCV = await _context.JobCV
                .FirstOrDefaultAsync(m => m.JobCVID == id);
            if (jobCV == null)
            {
                return NotFound();
            }

            return View(jobCV);
        }

        // GET: JobCVs/Create
        [Authorize(Roles = "Jobseeker")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobCVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobCVID")] JobCV jobCV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobCV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobCV);
        }

        // GET: JobCVs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCV = await _context.JobCV.FindAsync(id);
            if (jobCV == null)
            {
                return NotFound();
            }
            return View(jobCV);
        }

        // POST: JobCVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Jobseeker")]
        public async Task<IActionResult> Edit(int id, [Bind("JobCVID")] JobCV jobCV)
        {
            if (id != jobCV.JobCVID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobCV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobCVExists(jobCV.JobCVID))
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
            return View(jobCV);
        }

        // GET: JobCVs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCV = await _context.JobCV
                .FirstOrDefaultAsync(m => m.JobCVID == id);
            if (jobCV == null)
            {
                return NotFound();
            }

            return View(jobCV);
        }

        // POST: JobCVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Employer, Jobseeker")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobCV = await _context.JobCV.FindAsync(id);
            _context.JobCV.Remove(jobCV);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobCVExists(int id)
        {
            return _context.JobCV.Any(e => e.JobCVID == id);
        }
    }
}
