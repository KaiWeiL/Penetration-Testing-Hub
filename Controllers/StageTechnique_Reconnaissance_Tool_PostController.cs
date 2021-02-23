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
    public class StageTechnique_Reconnaissance_Tool_PostController : Controller
    {
        private readonly PTHDbContext _context;

        public StageTechnique_Reconnaissance_Tool_PostController(PTHDbContext context)
        {
            _context = context;
        }

        // GET: StageTechnique_Reconnaissance_Tool_Post
        public async Task<IActionResult> Index()
        {
            var pTHDbContext = _context.StageTechnique_Reconnaissance_Tool_Posts.Include(s => s.StageTechnique_Reconnaissance_Tool);
            return View(await pTHDbContext.ToListAsync());
        }

        // GET: StageTechnique_Reconnaissance_Tool_Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageTechnique_Reconnaissance_Tool_Post = await _context.StageTechnique_Reconnaissance_Tool_Posts
                .Include(s => s.StageTechnique_Reconnaissance_Tool)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stageTechnique_Reconnaissance_Tool_Post == null)
            {
                return NotFound();
            }

            return View(stageTechnique_Reconnaissance_Tool_Post);
        }

        // GET: StageTechnique_Reconnaissance_Tool_Post/Create
        public IActionResult Create()
        {
            ViewData["StageTechnique_Reconnaissance_ToolId"] = new SelectList(_context.StageTechnique_Reconnaissance_Tools, "Id", "Id");
            return View();
        }

        // POST: StageTechnique_Reconnaissance_Tool_Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,OP,PostTime,PostFileName,StageTechnique_Reconnaissance_ToolId")] StageTechnique_Reconnaissance_Tool_Post stageTechnique_Reconnaissance_Tool_Post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stageTechnique_Reconnaissance_Tool_Post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StageTechnique_Reconnaissance_ToolId"] = new SelectList(_context.StageTechnique_Reconnaissance_Tools, "Id", "Id", stageTechnique_Reconnaissance_Tool_Post.StageTechnique_Reconnaissance_ToolId);
            return View(stageTechnique_Reconnaissance_Tool_Post);
        }

        // GET: StageTechnique_Reconnaissance_Tool_Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageTechnique_Reconnaissance_Tool_Post = await _context.StageTechnique_Reconnaissance_Tool_Posts.FindAsync(id);
            if (stageTechnique_Reconnaissance_Tool_Post == null)
            {
                return NotFound();
            }
            ViewData["StageTechnique_Reconnaissance_ToolId"] = new SelectList(_context.StageTechnique_Reconnaissance_Tools, "Id", "Id", stageTechnique_Reconnaissance_Tool_Post.StageTechnique_Reconnaissance_ToolId);
            return View(stageTechnique_Reconnaissance_Tool_Post);
        }

        // POST: StageTechnique_Reconnaissance_Tool_Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,OP,PostTime,PostFileName,StageTechnique_Reconnaissance_ToolId")] StageTechnique_Reconnaissance_Tool_Post stageTechnique_Reconnaissance_Tool_Post)
        {
            if (id != stageTechnique_Reconnaissance_Tool_Post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stageTechnique_Reconnaissance_Tool_Post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StageTechnique_Reconnaissance_Tool_PostExists(stageTechnique_Reconnaissance_Tool_Post.Id))
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
            ViewData["StageTechnique_Reconnaissance_ToolId"] = new SelectList(_context.StageTechnique_Reconnaissance_Tools, "Id", "Id", stageTechnique_Reconnaissance_Tool_Post.StageTechnique_Reconnaissance_ToolId);
            return View(stageTechnique_Reconnaissance_Tool_Post);
        }

        // GET: StageTechnique_Reconnaissance_Tool_Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageTechnique_Reconnaissance_Tool_Post = await _context.StageTechnique_Reconnaissance_Tool_Posts
                .Include(s => s.StageTechnique_Reconnaissance_Tool)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stageTechnique_Reconnaissance_Tool_Post == null)
            {
                return NotFound();
            }

            return View(stageTechnique_Reconnaissance_Tool_Post);
        }

        // POST: StageTechnique_Reconnaissance_Tool_Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stageTechnique_Reconnaissance_Tool_Post = await _context.StageTechnique_Reconnaissance_Tool_Posts.FindAsync(id);
            _context.StageTechnique_Reconnaissance_Tool_Posts.Remove(stageTechnique_Reconnaissance_Tool_Post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StageTechnique_Reconnaissance_Tool_PostExists(int id)
        {
            return _context.StageTechnique_Reconnaissance_Tool_Posts.Any(e => e.Id == id);
        }
    }
}
