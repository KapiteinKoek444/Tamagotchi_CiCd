using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Shared.Shared.ApiModels
{
	[ExcludeFromCodeCoverage]
	public class FoodModel
	{
		public Guid id { get; set; }

		public string name { get; set; }
		public string category { get; set; }

		public double price { get; set; }
		public double discount { get; set; }

		public double foodVal { get; set; }
		public double energyVal { get; set; }
		public double happyVal { get; set; }
	}
}
