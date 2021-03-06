﻿using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsPopularRequest : TraktGetRequest<IEnumerable<TraktShow>> {

		internal TraktShowsPopularRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/popular"; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

		protected override bool SupportsPagination { get { return true; } }

	}

}