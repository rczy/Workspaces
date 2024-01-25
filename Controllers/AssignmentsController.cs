using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Workspaces.Data;
using Workspaces.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Workspaces.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly WorkspacesDbContext _context;

        public AssignmentsController(WorkspacesDbContext context)
        {
            _context = context;
        }


        // GET: Assignments
        public async Task<IActionResult> Index()
        {
            var workspacesDbContext = _context.Assignments.Include(a => a.Employee).Include(a => a.Workspace);
            return View(await workspacesDbContext.ToListAsync());
        }

        // GET: Assignments/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["WorkspaceId"] = new SelectList(_context.Workspaces, "Id", "Name");
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,WorkspaceId,Date")] Assignment assignment)
        {
            string? error = null;
            if (EmployeeAlreadyAssigned(assignment.EmployeeId, assignment.Date)) {
                error = "This employee has been already assigned to a workspace on the given date.";
            }
            else if (!HasCapacity(assignment.WorkspaceId, assignment.Date)) {
                error = "Workspace is already full.";
            }

            if (error == null && ModelState.IsValid)
            {
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", assignment.EmployeeId);
            ViewData["WorkspaceId"] = new SelectList(_context.Workspaces, "Id", "Name", assignment.WorkspaceId);
            ViewData["Error"] = error;
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", assignment.EmployeeId);
            ViewData["WorkspaceId"] = new SelectList(_context.Workspaces, "Id", "Name", assignment.WorkspaceId);
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,WorkspaceId,Date")] Assignment assignment)
        {
            if (id != assignment.Id)
            {
                return NotFound();
            }

            string? error = null;
            if (EmployeeAlreadyAssigned(assignment.EmployeeId, assignment.Date))
            {
                error = "This employee has been already assigned to a workspace on the given date.";
            }
            else if(!HasCapacity(assignment.WorkspaceId, assignment.Date))
            {
                error = "Workspace is already full.";
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", assignment.EmployeeId);
            ViewData["WorkspaceId"] = new SelectList(_context.Workspaces, "Id", "Name", assignment.WorkspaceId);
            ViewData["Error"] = error;
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Employee)
                .Include(a => a.Workspace)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.Id == id);
        }

        private bool HasCapacity(int workspaceId, DateOnly date)
        {
            var workspace = _context.Workspaces.Find(workspaceId);
            var count = _context.Assignments.Count(a => a.WorkspaceId == workspaceId && a.Date == date);
            return count != workspace.Capacity;
        }

        private bool EmployeeAlreadyAssigned(int employeeId, DateOnly date)
        {
            return _context.Assignments.Any(a => a.EmployeeId == employeeId && a.Date == date);
        }
    }
}
