﻿using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.RequestBody.OAuth {

	[Serializable]
	public class TraktOAuthTokenRequestBody {

		[JsonProperty(PropertyName = "code", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string Code { get; set; }

		[JsonProperty(PropertyName = "refresh_token", DefaultValueHandling = DefaultValueHandling.Ignore)]
		public string RefreshToken { get; set; }

		[JsonProperty(PropertyName = "client_id")]
		public string ClientId { get; set; }

		[JsonProperty(PropertyName = "client_secret")]
		public string ClientSecret { get; set; }

		[JsonProperty(PropertyName = "redirect_uri")]
		public string RedirectUri { get; set; }

		[JsonProperty(PropertyName = "grant_type")]
		public string GrantType { get; set; }

	}

}