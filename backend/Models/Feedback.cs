using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Feedback.Api.Models;

public class Feedback
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("recipient")]
    public string Recipient { get; set; } = null!;

    [BsonElement("feedback_text")]
    public string FeedbackText { get; set; } = null!;

    [BsonElement("feedback_type")]
    public string FeedbackType { get; set; } = null!; // "kudos" or "constructive"

    [BsonElement("submitted_at")]
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
}
