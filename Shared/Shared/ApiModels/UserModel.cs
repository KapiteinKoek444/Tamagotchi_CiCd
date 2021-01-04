﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Shared.ApiModels
{
	public class UserModel
	{
		[BsonId]
		public Guid Id { get; set; }

		public string Email { get; set; }
		public string Password { get; set; }
	}
}
