﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Factories;
using TraktSharp.Request.Comments;

namespace TraktSharp.Modules {

	public class TraktCommentsModule {

		public TraktCommentsModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktComment> PostMovieCommentAsync(string movieId, StringMovieIdType movieIdType, string comment, bool spoiler = false, bool review = false) {
			return await PostMovieCommentAsync(TraktMovieFactory.FromId(movieId, movieIdType), comment, spoiler, review);
		}

		public async Task<TraktComment> PostMovieCommentAsync(int movieId, IntMovieIdType movieIdType, string comment, bool spoiler = false, bool review = false) {
			return await PostMovieCommentAsync(TraktMovieFactory.FromId(movieId, movieIdType), comment, spoiler, review);
		}

		public async Task<TraktComment> PostMovieCommentAsync(string movieTitle, int? movieYear, string comment, bool spoiler = false, bool review = false) {
			return await PostMovieCommentAsync(TraktMovieFactory.FromTitleAndYear(movieTitle, movieYear), comment, spoiler, review);
		}

		public async Task<TraktComment> PostMovieCommentAsync(TraktMovie movie, string comment, bool spoiler = false, bool review = false) {
			return await new TraktCommentsPostMovieRequest(Client) {
				RequestBody = new TraktMovieComment {
					Movie = movie,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			}.SendAsync();
		}

		public async Task<TraktComment> PostShowCommentAsync(string showId, StringShowIdType showIdType, string comment, bool spoiler = false, bool review = false) {
			return await PostShowCommentAsync(TraktShowFactory.FromId(showId, showIdType), comment, spoiler, review);
		}

		public async Task<TraktComment> PostShowCommentAsync(int showId, IntShowIdType showIdType, string comment, bool spoiler = false, bool review = false) {
			return await PostShowCommentAsync(TraktShowFactory.FromId(showId, showIdType), comment, spoiler, review);
		}

		public async Task<TraktComment> PostShowCommentAsync(string showTitle, int? showYear, string comment, bool spoiler = false, bool review = false) {
			return await PostShowCommentAsync(TraktShowFactory.FromTitleAndYear(showTitle, showYear), comment, spoiler, review);
		}

		public async Task<TraktComment> PostShowCommentAsync(TraktShow show, string comment, bool spoiler = false, bool review = false) {
			return await new TraktCommentsPostShowRequest(Client) {
				RequestBody = new TraktShowComment {
					Show = show,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			}.SendAsync();
		}

		public async Task<TraktComment> PostEpisodeCommentAsync(string episodeId, StringEpisodeIdType episodeIdType, string comment, bool spoiler = false, bool review = false) {
			return await PostEpisodeCommentAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), comment, spoiler, review);
		}

		public async Task<TraktComment> PostEpisodeCommentAsync(int episodeId, IntEpisodeIdType episodeIdType, string comment, bool spoiler = false, bool review = false) {
			return await PostEpisodeCommentAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), comment, spoiler, review);
		}

		public async Task<TraktComment> PostEpisodeCommentAsync(TraktEpisode episode, string comment, bool spoiler = false, bool review = false) {
			return await new TraktCommentsPostEpisodeRequest(Client) {
				RequestBody = new TraktEpisodeComment {
					Episode = episode,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			}.SendAsync();
		}

		public async Task<TraktComment> PostListCommentAsync(string listId, string comment, bool spoiler = false, bool review = false) {
			return await PostListCommentAsync(TraktListFactory.FromId(listId), comment, spoiler, review);
		}

		public async Task<TraktComment> PostListCommentAsync(int listId, string comment, bool spoiler = false, bool review = false) {
			return await PostListCommentAsync(TraktListFactory.FromId(listId), comment, spoiler, review);
		}

		public async Task<TraktComment> PostListCommentAsync(TraktList list, string comment, bool spoiler = false, bool review = false) {
			return await new TraktCommentsPostListRequest(Client) {
				RequestBody = new TraktListComment {
					List = list,
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			}.SendAsync();
		}

		public async Task<TraktComment> GetCommentAsync(TraktComment comment) {
			return await GetCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture));
		}

		public async Task<TraktComment> GetCommentAsync(string commentId) {
			return await new TraktCommentsGetRequest(Client) { Id = commentId }.SendAsync();
		}

		public async Task<TraktComment> UpdateCommentAsync(TraktComment comment) {
			return await UpdateCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture), comment.Comment, comment.Spoiler.GetValueOrDefault(false), comment.Review.GetValueOrDefault(false));
		}

		public async Task<TraktComment> UpdateCommentAsync(string commentId, string comment, bool spoiler = false, bool review = false) {
			return await new TraktCommentsUpdateRequest(Client) {
				Id = commentId,
				RequestBody = new TraktComment {
					Comment = comment,
					Spoiler = spoiler,
					Review = review
				}
			}.SendAsync();
		}

		public async Task DeleteCommentAsync(TraktComment comment) {
			await DeleteCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture));
		}

		public async Task DeleteCommentAsync(string commentId) {
			await new TraktCommentsDeleteRequest(Client) { Id = commentId }.SendAsync();
		}

		public async Task<IEnumerable<TraktComment>> GetRepliesAsync(string commentId) {
			return await new TraktCommentsRepliesRequest(Client) { Id = commentId }.SendAsync();
		}

		public async Task<TraktComment> ReplyToCommentAsync(string commentId, string comment, bool spoiler = false) {
			return await new TraktCommentsReplyRequest(Client) {
				Id = commentId,
				RequestBody = new TraktComment {
					Comment = comment,
					Spoiler = spoiler
				}
			}.SendAsync();
		}

		public async Task<TraktComment> LikeCommentAsync(TraktComment comment) {
			return await LikeCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture));
		}

		public async Task<TraktComment> LikeCommentAsync(string commentId) {
			return await new TraktCommentsLikeRequest(Client) { Id = commentId }.SendAsync();
		}

		public async Task UnlikeCommentAsync(TraktComment comment) {
			await UnlikeCommentAsync(comment.Id.GetValueOrDefault().ToString(CultureInfo.InvariantCulture));
		}

		public async Task UnlikeCommentAsync(string commentId) {
			await new TraktCommentsUnlikeRequest(Client) { Id = commentId }.SendAsync();
		}

	}

}