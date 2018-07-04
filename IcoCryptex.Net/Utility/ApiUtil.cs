using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IcoCryptex.Net.Client;
using IcoCryptex.Net.Extensions;

namespace IcoCryptex.Net.Utility
{
    public class ApiUtil
    {
        internal const string ApiVersion = "v1";

        private readonly string _host;
        private readonly ushort _port;
        private readonly IceClient _client;
        private readonly string _scheme;

        public ApiUtil(string host, ushort port, bool ssl, IceClient client)
        {
            _host = host;
            _port = port;
            _client = client;
            _scheme = ssl ? "https" : "http";
        }

        public Task<string> Get(string pathAndQuery, bool secureCall = true) => Call(HttpMethod.Get, pathAndQuery, null, secureCall);
        public Task<T> Get<T>(string pathAndQuery, bool secureCall = true) => Get(pathAndQuery, secureCall).ThenDeserializeAs<T>();

        public Task<string> Delete(string pathAndQuery, bool secureCall = true) => Call(HttpMethod.Delete, pathAndQuery, null, secureCall);
        public Task<T> Delete<T>(string pathAndQuery, bool secureCall = true) => Delete(pathAndQuery, secureCall).ThenDeserializeAs<T>();

        public Task<string> Post(string pathAndQuery, object data, bool secureCall = true) => Call(HttpMethod.Post, pathAndQuery, data, secureCall);
        public Task<T> Post<T>(string pathAndQuery, object data, bool secureCall = true) => Post(pathAndQuery, data, secureCall).ThenDeserializeAs<T>();

        public Task<string> Put(string pathAndQuery, object data, bool secureCall = true) => Call(HttpMethod.Put, pathAndQuery, data, secureCall);
        public Task<T> Put<T>(string pathAndQuery, object data, bool secureCall = true) => Put(pathAndQuery, data, secureCall).ThenDeserializeAs<T>();

        public Task<string> Call(HttpMethod method, string pathAndQuery, object data, bool secureCall = true)
        {
            var url = new UriBuilder(_scheme,_host,_port, $"/{ApiVersion}/{pathAndQuery.Trim('/')}".TrimEnd('/'));
            // Add a new Request Message
            var headers = new Dictionary<string, string>();
            if (secureCall)
            {
                var nonce = GetNonce();
                // Add our custom headers
                headers.Add("key", _client.Identity.Key);
                headers.Add("nonce", nonce.ToString());
                headers.Add("sign", Signature.Create(_client.Identity.Secret, url.Path, nonce));
            }

            if (method == HttpMethod.Get)
            {
                return WebUtility.Get(url.Uri.ToString(), headers);
            }

            if (method == HttpMethod.Post)
            {
                return WebUtility.Post(url.Uri.ToString(), data, headers);
            }

            if (method == HttpMethod.Put)
            {
                return WebUtility.Put(url.Uri.ToString(), data, headers);
            }

            if (method == HttpMethod.Delete)
            {
                return WebUtility.Delete(url.Uri.ToString(), headers);
            }
            
            throw new NotImplementedException();
        }

        public long GetNonce()
        {
            lock (ApiVersion)
            {
                Thread.Sleep(1);
                return DateTime.UtcNow.Ticks;
            }
        }
    }
}