using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IcoCryptex.Net.Client;
using IcoCryptex.Net.Extensions;
using Newtonsoft.Json;

namespace IcoCryptex.Net.Utility
{
    public class ApiUtil
    {
        private static readonly Encoding Encoding = Encoding.UTF8;
        internal const string ApiVersion = "v1";

        private readonly string _host;
        private readonly ushort _port;
        private readonly IceClient _client;
        private string _scheme;

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

        public async Task<string> Call(HttpMethod method, string pathAndQuery, object data, bool secureCall = true)
        {
            var url = new UriBuilder(_scheme,_host,_port, $"{ApiVersion}/{pathAndQuery.Trim('/')}".TrimEnd('/'));
            // Add a new Request Message
            var requestMessage = new HttpRequestMessage(method, url.Uri);

            if (secureCall)
            {
                // Add our custom headers
                requestMessage.Headers.Add("key", _client.Identity.Key);
                requestMessage.Headers.Add("nonce", GetNonce().ToString());
                requestMessage.Headers.Add("sign", Signature.Create(_client.Identity.Secret, url.Path));
            }

            // Add request body
            var client = new HttpClient();
            if (data != null)
            {
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding);
            }
            // Send the request to the server
            var responseMessage = await client.SendAsync(requestMessage);
            var response = await responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"{responseMessage.ReasonPhrase} : {response}");
            }
            // Get the response
            return response;
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