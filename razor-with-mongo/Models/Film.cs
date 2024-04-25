using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Film
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BindNever] // Exclude from model binding
    public string? Id { get; set; }

    [BsonElement("filmTitle")]
    public string FilmTitle { get; set; }

    [BsonElement("filmCertificate")]
    public string FilmCertificate { get; set; }

    [BsonElement("filmDescription")]
    public string FilmDescription { get; set; }

    [BsonElement("filmImage")]
    public string? FilmImage { get; set; } // Nullable<string> for optional

    [BsonElement("filmPrice")]
    public decimal FilmPrice { get; set; }

    [BsonElement("stars")]
    public string Stars { get; set; }

    [BsonElement("releaseDate")]
    public DateTime ReleaseDate { get; set; }
}
