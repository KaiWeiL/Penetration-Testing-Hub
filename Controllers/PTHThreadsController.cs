using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Penetration_Testing_Hub.Data;
using Penetration_Testing_Hub.Models;

namespace Penetration_Testing_Hub.Controllers
{
    public class PTHThreadsController : Controller
    {
        private readonly PTHDbContext _context;

        public PTHThreadsController(PTHDbContext context)
        {
            _context = context;
        }

        // GET: PTHThreads
        public async Task<IActionResult> Index()
        {
            return View(await _context.PTHThreads.ToListAsync());
        }

        // GET: PTHThreads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pTHThread = await _context.PTHThreads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pTHThread == null)
            {
                return NotFound();
            }

            return View(pTHThread);
        }

        // GET: PTHThreads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PTHThreads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,CreatTime,ModifyTime,OP")] PTHThread pTHThread)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pTHThread);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pTHThread);
        }

        // GET: PTHThreads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pTHThread = await _context.PTHThreads.FindAsync(id);
            if (pTHThread == null)
            {
                return NotFound();
            }
            return View(pTHThread);
        }

        // POST: PTHThreads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,CreatTime,ModifyTime,OP")] PTHThread pTHThread)
        {
            if (id != pTHThread.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pTHThread);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PTHThreadExists(pTHThread.Id))
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
            return View(pTHThread);
        }

        // GET: PTHThreads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pTHThread = await _context.PTHThreads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pTHThread == null)
            {
                return NotFound();
            }

            return View(pTHThread);
        }

        // POST: PTHThreads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pTHThread = await _context.PTHThreads.FindAsync(id);
            _context.PTHThreads.Remove(pTHThread);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PTHThreadExists(int id)
        {
            return _context.PTHThreads.Any(e => e.Id == id);
        }
    }
}
