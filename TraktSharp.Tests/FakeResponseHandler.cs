﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace TraktSharp.Tests {

	public class FakeResponseHandler : DelegatingHandler {

		private readonly Dictionary<string, HttpResponseMessage> _fakeResponses = new Dictionary<string, HttpResponseMessage>();
		private string _responseFilename = "";

		private string ResponseFilePath {
			get {
				return string.IsNullOrEmpty(_responseFilename)
					? string.Empty
					: Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Response", _responseFilename);
			}
		}

		public void AddFakeResponse(string url, HttpStatusCode statusCode, string responseFilename) {
			_responseFilename = responseFilename;
			_fakeResponses[url] = new HttpResponseMessage(statusCode) {
				Content = new StringContent(string.IsNullOrEmpty(ResponseFilePath) ? string.Empty : File.ReadAllText(ResponseFilePath))
			};
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
			return await Task.Factory.StartNew(() => _fakeResponses.ContainsKey(request.RequestUri.AbsoluteUri)
				? _fakeResponses[request.RequestUri.AbsoluteUri]
				: new HttpResponseMessage(HttpStatusCode.NotFound) {
					RequestMessage = request,
					Content = new StringContent(string.Empty)
				}, cancellationToken);
		}

	}

}