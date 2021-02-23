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
    public class PTHPostsController : Controller
    {
        private readonly PTHDbContext _context;

        public PTHPostsController(PTHDbContext context)
        {
            _context = context;
        }

        // GET: PTHPosts
        public async Task<IActionResult> Index(string ThreadId)
        {
            //HttpContext.Session.SetString("ThreadId", ThreadId);
            var pTHDbContext = _context.PTHPosts.Include(p => p.PTHThread).Where(p => p.PTHThreadId.ToString() == ThreadId);
            return View(await pTHDbContext.ToListAsync());
        }

        // GET: PTHPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pTHPost = await _context.PTHPosts
                .Include(p => p.PTHThread)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pTHPost == null)
            {
                return NotFound();
            }

            return View(pTHPost);
        }

        // GET: PTHPosts/Create
        public IActionResult Create()
        {
            ViewData["PTHThreadId"] = new SelectList(_context.PTHThreads, "Id", "Id");
            return View();
        }

        // POST: PTHPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,OP,PostTime,PostFileName,PTHThreadId")] PTHPost pTHPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pTHPost);
                await _context.SaveChangesAsync();

                //fixed empty list after creation through passing ThreadId for redirection
                return RedirectToAction(nameof(Index), new { ThreadId = pTHPost.PTHThreadId});
            }
            ViewData["PTHThreadId"] = new SelectList(_context.PTHThreads, "Id", "Id", pTHPost.PTHThreadId);
            return View(pTHPost);
        }

        // GET: PTHPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pTHPost = await _context.PTHPosts.FindAsync(id);
            if (pTHPost == null)
            {
                return NotFound();
            }
            ViewData["PTHThreadId"] = new SelectList(_context.PTHThreads, "Id", "Id", pTHPost.PTHThreadId);
            return View(pTHPost);
        }

        // POST: PTHPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,OP,PostTime,PostFileName,PTHThreadId")] PTHPost pTHPost)
        {
            if (id != pTHPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pTHPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PTHPostExists(pTHPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { ThreadId = pTHPost.PTHThreadId });
            }
            ViewData["PTHThreadId"] = new SelectList(_context.PTHThreads, "Id", "Id", pTHPost.PTHThreadId);
            return View(pTHPost);
        }

        // GET: PTHPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pTHPost = await _context.PTHPosts
                .Include(p => p.PTHThread)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pTHPost == null)
            {
                return NotFound();
            }

            return View(pTHPost);
        }

        // POST: PTHPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pTHPost = await _context.PTHPosts.FindAsync(id);
            _context.PTHPosts.Remove(pTHPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { ThreadId = pTHPost.PTHThreadId });
        }

        private bool PTHPostExists(int id)
        {
            return _context.PTHPosts.Any(e => e.Id == id);
        }
    }
}
