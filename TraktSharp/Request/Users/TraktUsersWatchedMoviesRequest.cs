﻿using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	public class TraktUsersWatchedMoviesRequest : TraktGetByUsernameRequest<IEnumerable<TraktWatchedMoviesResponseItem>> {

		public TraktUsersWatchedMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/watched/movies"; } }

	}

}