using Feedback.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Feedback.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly MongoDbService _mongoDbService;
    private readonly ILogger<FeedbackController> _logger;

    public FeedbackController(MongoDbService mongoDbService, ILogger<FeedbackController> logger)
    {
        _mongoDbService = mongoDbService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<List<Models.Feedback>> Get()
    {
        _logger.LogInformation("Received GET request for all feedback.");
        return await _mongoDbService.GetAsync();
    }

    [HttpGet("analytics")]
    public async Task<ActionResult<object>> GetAnalytics()
    {
        _logger.LogInformation("Received GET request for analytics.");
        try
        {
            var allFeedback = await _mongoDbService.GetAsync();
            var totalFeedback = allFeedback.Count;
            var averageRating = totalFeedback > 0 ? allFeedback.Average(f => f.Rating) : 0;

            return Ok(new { totalFeedback, averageRating });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting analytics data.");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Models.Feedback>> Get(string id)
    {
        _logger.LogInformation("Received GET request for feedback with ID: {Id}", id);
        var feedback = await _mongoDbService.GetAsync(id);

        if (feedback is null)
        {
            return NotFound();
        }

        return feedback;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Models.Feedback newFeedback)
    {
        _logger.LogInformation("Received POST request to create feedback for recipient: {Recipient}", newFeedback.Recipient);
        try
        {
            await _mongoDbService.CreateAsync(newFeedback);
            return CreatedAtAction(nameof(Get), new { id = newFeedback.Id }, newFeedback);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating feedback.");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Models.Feedback updatedFeedback)
    {
        _logger.LogInformation("Received PUT request to update feedback with ID: {Id}", id);
        var feedback = await _mongoDbService.GetAsync(id);

        if (feedback is null)
        {
            return NotFound();
        }

        updatedFeedback.Id = feedback.Id;

        try
        {
            await _mongoDbService.UpdateAsync(id, updatedFeedback);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating feedback with ID: {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        _logger.LogInformation("Received DELETE request for feedback with ID: {Id}", id);
        var feedback = await _mongoDbService.GetAsync(id);

        if (feedback is null)
        {
            return NotFound();
        }

        try
        {
            await _mongoDbService.RemoveAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting feedback with ID: {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }
}
