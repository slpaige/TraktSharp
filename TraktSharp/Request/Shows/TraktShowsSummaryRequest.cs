﻿using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Shows {

	public class TraktShowsSummaryRequest : TraktGetByIdRequest<TraktShow> {

		public TraktShowsSummaryRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

	}

}