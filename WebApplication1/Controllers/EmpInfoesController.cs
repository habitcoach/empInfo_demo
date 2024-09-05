using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmpInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmpInfoes
        public async Task<IActionResult> Index()
        {
              return _context.empInfos != null ? 
                          View(await _context.empInfos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.empInfos'  is null.");
        }

        // GET: EmpInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.empInfos == null)
            {
                return NotFound();
            }

            var empInfo = await _context.empInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empInfo == null)
            {
                return NotFound();
            }

            return View(empInfo);
        }

        // GET: EmpInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,JobTitle,DeptName,Email,Ext,Direct,Mobile")] EmpInfo empInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empInfo);
        }

        // GET: EmpInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.empInfos == null)
            {
                return NotFound();
            }

            var empInfo = await _context.empInfos.FindAsync(id);
            if (empInfo == null)
            {
                return NotFound();
            }
            return View(empInfo);
        }

        // POST: EmpInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,JobTitle,DeptName,Email,Ext,Direct,Mobile")] EmpInfo empInfo)
        {
            if (id != empInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpInfoExists(empInfo.Id))
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
            return View(empInfo);
        }

        // GET: EmpInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.empInfos == null)
            {
                return NotFound();
            }

            var empInfo = await _context.empInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empInfo == null)
            {
                return NotFound();
            }

            return View(empInfo);
        }

        // POST: EmpInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.empInfos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.empInfos'  is null.");
            }
            var empInfo = await _context.empInfos.FindAsync(id);
            if (empInfo != null)
            {
                _context.empInfos.Remove(empInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpInfoExists(int id)
        {
          return (_context.empInfos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
