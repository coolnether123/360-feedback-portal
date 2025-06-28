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

    [BsonElement("what_went_well")]
    public string WhatWentWell { get; set; } = null!;

    [BsonElement("what_could_improve")]
    public string WhatCouldImprove { get; set; } = null!;

    [BsonElement("rating")]
    public int Rating { get; set; }

    [BsonElement("submitted_at")]
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
}
