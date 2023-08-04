using Microsoft.EntityFrameworkCore;
using Tracking.Api.Context;
using Tracking.Api.Models;

namespace Tracking.Api.Repository
{
    public class IssueRepository : IIssueRepository
    {
        private readonly IssueDbContext _context;

        public IssueRepository(IssueDbContext context) => _context = context;

        public async Task Create(Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Issue issue)
        {
            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Issue>> GetAll()
        {
            return await _context.Issues.ToListAsync();
        }

        public async Task<Issue> GetById(int id)
        {
            return await _context.Issues.FindAsync(id);
        }

        public async Task Update(Issue issue)
        {
            _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
