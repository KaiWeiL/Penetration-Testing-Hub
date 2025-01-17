﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Penetration_Testing_Hub.Data;
using Penetration_Testing_Hub.Models;
using Microsoft.AspNetCore.Authorization;

namespace Penetration_Testing_Hub.Controllers
{

    [Authorize(Roles= "Administrator,PTHmember")]
    public class PTHThreadsController : Controller
    {
        private readonly PTHDbContext _context;

        public PTHThreadsController(PTHDbContext context)
        {
            _context = context;
        }

        // GET: PTHThreads
        public async Task<IActionResult> Index(string ThreadCategory, string ToolOrTech)
        {
            ViewBag.ThreadCategory = ThreadCategory;
            ViewBag.ToolOrTech = ToolOrTech;
            return View(await _context.PTHThreads.Where(p => p.ThreadCategory
                        .ToString().Equals(ThreadCategory)).Where(p => p.ToolOrTech.Equals(ToolOrTech)).ToListAsync());
        }

        // GET: PTHThreads/Details/5
        [Authorize(Roles = "Administrator")]

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
        public IActionResult Create(string ThreadCategory, string ToolOrTech)
        {
            ViewBag.ThreadCategory = ThreadCategory;
            ViewBag.ToolOrTech = ToolOrTech;
            return View();
        }

        // POST: PTHThreads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,CreatTime,ModifyTime,OP,ThreadCategory,ToolOrTech")] PTHThread pTHThread)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pTHThread);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),
                        controllerName: "PTHThreads",
                        routeValues: new { ThreadCategory = pTHThread.ThreadCategory, ToolOrTech = pTHThread.ToolOrTech }
                );
            }
            return View(pTHThread);
        }

        // GET: PTHThreads/Edit/5
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
        [Authorize(Roles = "Administrator")]
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
