using Feedback.Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Feedback.Api.Services;

public class MongoDbService
{
    private readonly IMongoCollection<Models.Feedback> _feedbackCollection;

    public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
        _feedbackCollection = mongoDatabase.GetCollection<Models.Feedback>(mongoDbSettings.Value.CollectionName);
    }

    public async Task<List<Models.Feedback>> GetAsync() =>
        await _feedbackCollection.Find(_ => true).ToListAsync();

    public async Task<Models.Feedback?> GetAsync(string id) =>
        await _feedbackCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Models.Feedback newFeedback) =>
        await _feedbackCollection.InsertOneAsync(newFeedback);

    public async Task UpdateAsync(string id, Models.Feedback updatedFeedback) =>
        await _feedbackCollection.ReplaceOneAsync(x => x.Id == id, updatedFeedback);

    public async Task RemoveAsync(string id) =>
        await _feedbackCollection.DeleteOneAsync(x => x.Id == id);
}
