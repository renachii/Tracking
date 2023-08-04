using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tracking.Api.Repository;
using Tracking.Api.Models;

namespace Tracking.Api.Controllers
{
    [Route("tracking/issues")]
    [ApiController]
    public class IssueController : ControllerBase
    {

        private readonly IIssueRepository _issue;

        public IssueController(IIssueRepository issue) => _issue = issue;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var issues = await _issue.GetAll();
            return issues == null ? NotFound() : Ok(issues);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = _issue.GetById(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _issue.Create(issue);

            return CreatedAtAction(nameof(GetById), new {id = issue.Id}, issue);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(int id, Issue issue)
        {
            if (id != issue.Id)
            {
                return BadRequest();
            }

            await _issue.Update(issue);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id, Issue issue)
        {
            var issueToDelete = await _issue.GetById(id);
            if (issueToDelete == null)
            {
                return NotFound();
            }

            await _issue.Delete(issue);

            return NoContent();
        }
    }
}
