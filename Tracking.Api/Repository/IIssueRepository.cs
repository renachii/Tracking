using Tracking.Api.Models;

namespace Tracking.Api.Repository
{
    public interface IIssueRepository
    {
        Task<IEnumerable<Issue>> GetAll();
        Task<Issue> GetById (int id);
        Task Create(Issue issue);
        Task Update(Issue issue);
        Task Delete(Issue issue);
    }
}
