using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Penetration_Testing_Hub.Data;
using Penetration_Testing_Hub.Models;

namespace Penetration_Testing_Hub.Controllers
{
    public class StageTechnique_Reconnaissance_ToolController : Controller
    {
        private readonly PTHDbContext _context;


        public StageTechnique_Reconnaissance_ToolController(PTHDbContext context)
        {
            _context = context;
        }

        // GET: StageTechnique_Reconnaissance_Tool
        public async Task<IActionResult> Index()
        {
            return View(await _context.StageTechnique_Reconnaissance_Tools.ToListAsync());
        }

        // GET: StageTechnique_Reconnaissance_Tool/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageTechnique_Reconnaissance_Tool = await _context.StageTechnique_Reconnaissance_Tools
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stageTechnique_Reconnaissance_Tool == null)
            {
                return NotFound();
            }

            return View(stageTechnique_Reconnaissance_Tool);
        }

        // GET: StageTechnique_Reconnaissance_Tool/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StageTechnique_Reconnaissance_Tool/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,CreatTime,ModifyTime,OP")] StageTechnique_Reconnaissance_Tool stageTechnique_Reconnaissance_Tool)
        {
            
            if (ModelState.IsValid)
            {

                _context.Add(stageTechnique_Reconnaissance_Tool);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stageTechnique_Reconnaissance_Tool);
        }

        // GET: StageTechnique_Reconnaissance_Tool/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageTechnique_Reconnaissance_Tool = await _context.StageTechnique_Reconnaissance_Tools.FindAsync(id);
            if (stageTechnique_Reconnaissance_Tool == null)
            {
                return NotFound();
            }
            return View(stageTechnique_Reconnaissance_Tool);
        }

        // POST: StageTechnique_Reconnaissance_Tool/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,CreatTime,ModifyTime,OP")] StageTechnique_Reconnaissance_Tool stageTechnique_Reconnaissance_Tool)
        {
            if (id != stageTechnique_Reconnaissance_Tool.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stageTechnique_Reconnaissance_Tool);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StageTechnique_Reconnaissance_ToolExists(stageTechnique_Reconnaissance_Tool.Id))
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
            return View(stageTechnique_Reconnaissance_Tool);
        }

        // GET: StageTechnique_Reconnaissance_Tool/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageTechnique_Reconnaissance_Tool = await _context.StageTechnique_Reconnaissance_Tools
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stageTechnique_Reconnaissance_Tool == null)
            {
                return NotFound();
            }

            return View(stageTechnique_Reconnaissance_Tool);
        }

        // POST: StageTechnique_Reconnaissance_Tool/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stageTechnique_Reconnaissance_Tool = await _context.StageTechnique_Reconnaissance_Tools.FindAsync(id);
            _context.StageTechnique_Reconnaissance_Tools.Remove(stageTechnique_Reconnaissance_Tool);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StageTechnique_Reconnaissance_ToolExists(int id)
        {
            return _context.StageTechnique_Reconnaissance_Tools.Any(e => e.Id == id);
        }
    }
}
