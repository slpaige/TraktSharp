﻿using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	public class TraktCommentsGetRequest : TraktGetByIdRequest<TraktComment> {

		public TraktCommentsGetRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments/{id}"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

	}

}