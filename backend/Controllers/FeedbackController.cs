using Feedback.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly MongoDbService _mongoDbService;

    public FeedbackController(MongoDbService mongoDbService) =>
        _mongoDbService = mongoDbService;

    [HttpGet]
    public async Task<List<Models.Feedback>> Get() =>
        await _mongoDbService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Models.Feedback>> Get(string id)
    {
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
        await _mongoDbService.CreateAsync(newFeedback);

        return CreatedAtAction(nameof(Get), new { id = newFeedback.Id }, newFeedback);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Models.Feedback updatedFeedback)
    {
        var feedback = await _mongoDbService.GetAsync(id);

        if (feedback is null)
        {
            return NotFound();
        }

        updatedFeedback.Id = feedback.Id;

        await _mongoDbService.UpdateAsync(id, updatedFeedback);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var feedback = await _mongoDbService.GetAsync(id);

        if (feedback is null)
        {
            return NotFound();
        }

        await _mongoDbService.RemoveAsync(id);

        return NoContent();
    }
}
