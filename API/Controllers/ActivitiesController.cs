using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;


namespace API.Controllers
{
    public class ActivitiesController(DataContext context) : BaseApiController
    {
        private readonly DataContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Domain.Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Activity>> GetActivity(Guid id){
            return await _context.Activities.FindAsync(id);
        }
    }
}