using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Shared.Shared.ApiModels
{
	public class InventoryModel
	{
		[BsonId]
		public Guid id { get; set; }
		public Guid userId { get; set; }

		public List<Guid> itemId { get; set; }
	}
}
