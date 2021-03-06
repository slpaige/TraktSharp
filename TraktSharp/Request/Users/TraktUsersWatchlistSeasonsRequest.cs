﻿using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	internal class TraktUsersWatchlistSeasonsRequest : TraktGetByUsernameRequest<IEnumerable<TraktWatchlistSeasonsResponseItem>> {

		internal TraktUsersWatchlistSeasonsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/watchlist/seasons"; } }

	}

}