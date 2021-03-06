﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TraktSharp.Request {

	internal abstract class TraktPostByIdRequest<TResponse, TRequestBody> : TraktPostRequest<TResponse, TRequestBody> where TRequestBody : class {

		protected TraktPostByIdRequest(TraktClient client) : base(client) { }

		internal string Id { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"id", Id}
			};
		}

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(Id)) {
				throw new ArgumentException("Id not set.");
			}
		}

	}

}