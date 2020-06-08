using System;
using System.Collections.Generic;
using JustAMusician.Backend.Entities.Enums;

namespace JustAMusician.Backend.Entities.ResponseModels
{
	public class UserResponseModel
	{
		public int UserId { get; set; }
		public string Nickname { get; set; }
		public string Email { get; set; }
		public string About { get; set; }
		public DateTime SignedUpAt { get; set; }
		public Roles Role { get; set; }
		public List<BandResponseModelShort> Bands { get; set; }
		public List<string> Genres { get; set; }
		public List<string> Instruments { get; set; }
		public List<string> Links { get; set; }

		public UserResponseModel(User user)
		{
			UserId = user.UserId;
			Email = user.Email;
			About = user.About;
			Nickname = user.Nickname;
			SignedUpAt = user.SignedUpAt;
			Role = user.Role;
		}
	}
}