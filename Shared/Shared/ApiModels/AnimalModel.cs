using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Shared.Shared.ApiModels
{
	public class AnimalModel
	{
        [BsonId]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public float Food { get; set; }
        public float Energy { get; set; }
        public float Happiness { get; set; }

        public int AnimalType { get; set; }
    }
}
