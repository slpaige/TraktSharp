﻿using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.People;

namespace TraktSharp.Modules {

	public class TraktPeopleModule {

		public TraktPeopleModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktPerson> SummaryAsync(TraktPerson person, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SummaryAsync(person.Ids.GetBestId(), extended);
		}

		public async Task<TraktPerson> SummaryAsync(string personId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktPeopleSummaryRequest(Client) {
				Id = personId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktMovieCredits> MoviesAsync(TraktPerson person, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await MoviesAsync(person.Ids.GetBestId(), extended);
		}

		public async Task<TraktMovieCredits> MoviesAsync(string personId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktPeopleMoviesRequest(Client) {
				Id = personId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktShowCredits> ShowsAsync(TraktPerson person, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await ShowsAsync(person.Ids.GetBestId(), extended);
		}

		public async Task<TraktShowCredits> ShowsAsync(string personId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktPeopleShowsRequest(Client) {
				Id = personId,
				Extended = extended
			}.SendAsync();
		}

	}

}