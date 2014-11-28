﻿using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktSeasonIds {

		[JsonProperty(PropertyName = "tvdb")]
		public int? Tvdb { get; set; }

		[JsonProperty(PropertyName = "tmdb")]
		public int? Tmdb { get; set; }

		[JsonProperty(PropertyName = "tvrage")]
		public int? TvRage { get; set; }

		public bool HasAnyValuesSet() {
			return Tvdb > 0 || Tmdb > 0 || TvRage > 0;
		}

		public string GetBestId() {
			if (Tvdb.GetValueOrDefault() > 0) { return Tvdb.GetValueOrDefault().ToString(CultureInfo.InvariantCulture); }
			if (Tmdb.GetValueOrDefault() > 0) { return Tmdb.GetValueOrDefault().ToString(CultureInfo.InvariantCulture); }
			if (TvRage.GetValueOrDefault() > 0) { return TvRage.GetValueOrDefault().ToString(CultureInfo.InvariantCulture); }
			return string.Empty;
		}

	}

}