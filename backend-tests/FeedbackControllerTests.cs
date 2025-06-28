using Xunit;
using Moq;
using FluentAssertions;
using Feedback.Api.Controllers;
using Feedback.Api.Services;
using Feedback.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feedback.Api.Tests;

public class FeedbackControllerTests
{
    private readonly Mock<MongoDbService> _mongoDbServiceMock;
    private readonly FeedbackController _controller;

    public FeedbackControllerTests()
    {
        _mongoDbServiceMock = new Mock<MongoDbService>(null);
        _controller = new FeedbackController(_mongoDbServiceMock.Object);
    }

    [Fact]
    public async Task Get_ReturnsListOfFeedback()
    {
        // Arrange
        var feedbackList = new List<Models.Feedback>
        {
            new Models.Feedback { Id = "1", Recipient = "John Doe", FeedbackText = "Great job!", FeedbackType = "kudos" },
            new Models.Feedback { Id = "2", Recipient = "Jane Doe", FeedbackText = "Could improve.", FeedbackType = "constructive" }
        };
        _mongoDbServiceMock.Setup(service => service.GetAsync()).ReturnsAsync(feedbackList);

        // Act
        var result = await _controller.Get();

        // Assert
        result.Should().BeOfType<List<Models.Feedback>>();
        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetById_ReturnsFeedback_WhenFeedbackExists()
    {
        // Arrange
        var feedback = new Models.Feedback { Id = "1", Recipient = "John Doe", FeedbackText = "Great job!", FeedbackType = "kudos" };
        _mongoDbServiceMock.Setup(service => service.GetAsync("1")).ReturnsAsync(feedback);

        // Act
        var result = await _controller.Get("1");

        // Assert
        result.Result.Should().BeOfType<OkObjectResult>();
        var okResult = result.Result as OkObjectResult;
        okResult.Value.Should().BeEquivalentTo(feedback);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenFeedbackDoesNotExist()
    {
        // Arrange
        _mongoDbServiceMock.Setup(service => service.GetAsync("1")).ReturnsAsync((Models.Feedback)null);

        // Act
        var result = await _controller.Get("1");

        // Assert
        result.Result.Should().BeOfType<NotFoundResult>();
    }
}
