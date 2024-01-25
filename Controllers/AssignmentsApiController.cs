using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workspaces.Data;
using Workspaces.Models;

namespace Workspaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsApiController : ControllerBase
    {
        private readonly WorkspacesDbContext _context;

        public AssignmentsApiController(WorkspacesDbContext context)
        {
            _context = context;
        }

        [HttpGet("workspace/{workspaceId}")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignments(int workspaceId, string? dateFrom, string? dateTo)
        {
            var resultSet = _context.Assignments
                .Include(a => a.Employee)
                    .ThenInclude(e => e.Team)
                .Where(a => a.WorkspaceId == workspaceId);

            if (dateFrom != null)
            {
                resultSet = resultSet.Where(a => a.Date >= DateOnly.Parse(dateFrom));
            }
            if (dateTo != null)
            {
                resultSet = resultSet.Where(a => a.Date <= DateOnly.Parse(dateTo));
            }
            return await resultSet.OrderBy(a => a.Date).ToListAsync();
        }
    }
}
