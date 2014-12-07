﻿using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Entities.Response {

	[Serializable]
	public class TraktWatchlistEpisodesResponseItem {

		[JsonProperty(PropertyName = "listed_at")]
		public DateTime? RatedAt { get; set; }

		[JsonIgnore]
		public TraktListItemType Type { get; set; }

		[JsonProperty(PropertyName = "type")]
		private string TypeString { get { return TraktEnumHelper.GetDescription(Type); } }

		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

	}

}