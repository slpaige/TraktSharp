﻿using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Helpers;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktList {

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "privacy")]
		public string PrivacyString { get; set; }

		[JsonIgnore]
		public PrivacyOption Privacy {
			get { return EnumsHelper.FromDescription(PrivacyString, PrivacyOption.Unspecified); }
			set { PrivacyString = EnumsHelper.GetDescription(value); }
		}

		[JsonProperty(PropertyName = "display_numbers")]
		public bool? DisplayNumbers { get; set; }

		[JsonProperty(PropertyName = "allow_comments")]
		public bool? AllowComments { get; set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime? UpdatedAt { get; set; }

		[JsonProperty(PropertyName = "item_count")]
		public int? ItemCount { get; set; }

		[JsonProperty(PropertyName = "likes")]
		public int? Likes { get; set; }

		[JsonProperty(PropertyName = "ids")]
		public TraktListIds Ids { get; set; }

		public bool IsPostable() {
			return Ids != null && Ids.HasAnyValuesSet();
		}

	}

}