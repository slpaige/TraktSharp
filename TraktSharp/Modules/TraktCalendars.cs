﻿using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Request.Calendars;
using TraktSharp.Response.Calendars;

namespace TraktSharp.Modules {

	public class TraktCalendars {

		public TraktCalendars(TraktClient client) {
			Client = client;
		}

		public TraktClient Client { get; private set; }

		public async Task<TraktCalendarsShowsResponse> ShowsAsync(DateTime? startDate = null, int? days = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktCalendarsShowsRequest(Client) {
				StartDate = startDate,
				Days = days,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktCalendarsShowsResponse> ShowsNewAsync(DateTime? startDate = null, int? days = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktCalendarsShowsNewRequest(Client) {
				StartDate = startDate,
				Days = days,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktCalendarsShowsResponse> ShowsPremieresAsync(DateTime? startDate = null, int? days = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktCalendarsShowsPremieresRequest(Client) {
				StartDate = startDate,
				Days = days,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktCalendarsMoviesResponse> MoviesAsync(DateTime? startDate = null, int? days = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktCalendarsMoviesRequest(Client) {
				StartDate = startDate,
				Days = days,
				Extended = extended
			}.SendAsync();
		}

	}

}