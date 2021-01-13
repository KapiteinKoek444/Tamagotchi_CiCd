using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Shared.Shared.ApiModels
{
	[ExcludeFromCodeCoverage]
	public class InventoryModel
	{
		[BsonId]
		public Guid id { get; set; }
		public Guid userId { get; set; }

		public List<Guid> itemId { get; set; }
	}
}
