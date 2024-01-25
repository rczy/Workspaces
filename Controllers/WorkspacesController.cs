﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Workspaces.Data;
using Workspaces.Models;

namespace Workspaces.Controllers
{
    public class WorkspacesController : Controller
    {
        private readonly WorkspacesDbContext _context;

        public WorkspacesController(WorkspacesDbContext context)
        {
            _context = context;
        }

        // GET: Workspaces
        public async Task<IActionResult> Index()
        {
            return View(await _context.Workspaces.ToListAsync());
        }

        // GET: Workspaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workspaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Capacity")] Workspace workspace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workspace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workspace);
        }

        // GET: Workspaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workspace = await _context.Workspaces.FindAsync(id);
            if (workspace == null)
            {
                return NotFound();
            }
            return View(workspace);
        }

        // POST: Workspaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Capacity")] Workspace workspace)
        {
            if (id != workspace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workspace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkspaceExists(workspace.Id))
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
            return View(workspace);
        }

        // GET: Workspaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workspace = await _context.Workspaces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workspace == null)
            {
                return NotFound();
            }

            return View(workspace);
        }

        // POST: Workspaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workspace = await _context.Workspaces.FindAsync(id);
            if (workspace != null)
            {
                _context.Workspaces.Remove(workspace);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkspaceExists(int id)
        {
            return _context.Workspaces.Any(e => e.Id == id);
        }
    }
}
