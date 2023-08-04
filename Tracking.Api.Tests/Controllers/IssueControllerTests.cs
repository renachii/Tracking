using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Tracking.Api.Controllers;
using Tracking.Api.Models;
using Tracking.Api.Repository;

namespace Tracking.Api.Tests
{
    [TestFixture]
    public class IssueControllerTests
    {
        private readonly Mock<IIssueRepository> _issueRepoMock = new Mock<IIssueRepository>();

        [SetUp]
        public void Setup() 
        {
            
        }

        //[Test]
        //public async Task Get_OnSuccess_InvokesExactlyOnce()
        //{
        //    _issueRepoMock.Setup(repo => repo.GetAll())
        //        .ReturnsAsync(new List<Issue>());
        //    var sut = new IssueController(_issueRepoMock.Object);

        //    var result = await sut.Get();

        //    _issueRepoMock.Verify(
        //        repo => repo.GetAll(),
        //        Times.Once());
        //}

        [Test]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            _issueRepoMock.Setup(repo => repo.GetAll())
                .ReturnsAsync(new List<Issue>());
            var sut = new IssueController(_issueRepoMock.Object);

            var result = (OkObjectResult)await sut.Get();

            result.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task Get_OnSuccess_ReturnsListOfIssues()
        {
            _issueRepoMock.Setup(repo => repo.GetAll())
                .ReturnsAsync(new List<Issue>());
            var sut = new IssueController(_issueRepoMock.Object);

            var result = await sut.Get();

            result.Should().BeOfType<OkObjectResult>();
            var objResult = (OkObjectResult)result;
            objResult.Value.Should().BeOfType<List<Issue>>();
        }

        [Test]
        public async Task Get_OnNoIssues_ReturnsStatusCode404()
        {
            _issueRepoMock.Setup(repo => repo.GetAll())
                .ReturnsAsync(new List<Issue>());
            var sut = new IssueController(_issueRepoMock.Object);

            var result = (OkObjectResult)await sut.Get();

            result.StatusCode.Should().Be(404);
        }
    }
}