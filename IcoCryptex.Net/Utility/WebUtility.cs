using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IcoCryptex.Net.Utility
{
    public static class WebUtility 
    {
        public static HttpClient InternalHttpClient;

        static WebUtility()
        {
            InternalHttpClient = new HttpClient(new HttpClientHandler { UseProxy = false });
        }

        /////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////
        ////////////////////////// EXPOSED //////////////////////////
        /////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////
        public static Task<string> Get(string url, params Tuple<string, string>[] headers) => Get(url, requestHeaders => TupleHeaderConfiguration(requestHeaders, headers));
        public static Task<string> Get(string url, IReadOnlyDictionary<string, string> headers) => Get(url, requestHeaders => DictionaryHeaderConfiguration(requestHeaders, headers));
        public static Task<string> Get(string url, Action<HttpRequestHeaders> headerConfiguration = null)
        {
            return ProcessRequest(new HttpRequestMessage(HttpMethod.Get, url), headerConfiguration);
        }

        public static Task<string> Delete(string url, params Tuple<string, string>[] headers) => Delete(url, requestHeaders => TupleHeaderConfiguration(requestHeaders, headers));
        public static Task<string> Delete(string url, IReadOnlyDictionary<string, string> headers) => Delete(url, requestHeaders => DictionaryHeaderConfiguration(requestHeaders, headers));
        public static Task<string> Delete(string url, Action<HttpRequestHeaders> headerConfiguration = null)
        {
            return ProcessRequest(new HttpRequestMessage(HttpMethod.Delete, url), headerConfiguration);
        }

        public static Task<string> Post(string url, params Tuple<string, string>[] headers) => Post(url, requestHeaders => TupleHeaderConfiguration(requestHeaders, headers));
        public static Task<string> Post(string url, IReadOnlyDictionary<string, string> headers) => Post(url, requestHeaders => DictionaryHeaderConfiguration(requestHeaders, headers));
        public static Task<string> Post(string url, Action<HttpRequestHeaders> headerConfiguration = null)
        {
            return ProcessRequest(new HttpRequestMessage(HttpMethod.Post, url), headerConfiguration);
        }

        public static Task<string> Post(string url, object data, params Tuple<string, string>[] headers) => Post(url, data, (requestHeaders, contentHeaders) => TupleHeaderConfiguration(requestHeaders, headers));
        public static Task<string> Post(string url, object data, IReadOnlyDictionary<string, string> headers) => Post(url, data, (requestHeaders, contentHeaders) => DictionaryHeaderConfiguration(requestHeaders, headers));
        public static Task<string> Post(string url, object data, Action<HttpRequestHeaders, HttpContentHeaders> headerConfiguration = null)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            return ProcessRequest(new HttpRequestMessage(HttpMethod.Post, url) { Content = content }, headerConfiguration);
        }

        public static Task<string> PostForm(string url, NameValueCollection data, params Tuple<string, string>[] headers) => PostForm(url, data, (requestHeaders, contentHeaders) => TupleHeaderConfiguration(requestHeaders, headers));
        public static Task<string> PostForm(string url, NameValueCollection data, IReadOnlyDictionary<string, string> headers) => PostForm(url, data, (requestHeaders, contentHeaders) => DictionaryHeaderConfiguration(requestHeaders, headers));
        public static Task<string> PostForm(string url, NameValueCollection data, Action<HttpRequestHeaders, HttpContentHeaders> headerConfiguration = null)
        {
            var formData = string.Join("&", data.AllKeys.Select(key => $"{key}={data[key]}"));
            var content = new StringContent(formData, Encoding.UTF8, "application/x-www-form-urlencoded");
            return ProcessRequest(new HttpRequestMessage(HttpMethod.Post, url) { Content = content }, headerConfiguration);
        }

        public static Task<string> Put(string url, params Tuple<string, string>[] headers) => Put(url, requestHeaders => TupleHeaderConfiguration(requestHeaders, headers));
        public static Task<string> Put(string url, IReadOnlyDictionary<string, string> headers) => Put(url, requestHeaders => DictionaryHeaderConfiguration(requestHeaders, headers));
        public static Task<string> Put(string url, Action<HttpRequestHeaders> headerConfiguration = null)
        {
            return ProcessRequest(new HttpRequestMessage(HttpMethod.Put, url), headerConfiguration);
        }

        public static Task<string> Put(string url, object data, params Tuple<string, string>[] headers) => Put(url, data, (requestHeaders, contentHeaders) => TupleHeaderConfiguration(requestHeaders, headers));
        public static Task<string> Put(string url, object data, IReadOnlyDictionary<string, string> headers) => Put(url, data, (requestHeaders, contentHeaders) => DictionaryHeaderConfiguration(requestHeaders, headers));
        public static Task<string> Put(string url, object data, Action<HttpRequestHeaders, HttpContentHeaders> headerConfiguration = null)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            return ProcessRequest(new HttpRequestMessage(HttpMethod.Put, url) { Content = content }, headerConfiguration);
        }

        /////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////
        ///////////////////////// INTERNALS /////////////////////////
        /////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////
        private static void TupleHeaderConfiguration(HttpRequestHeaders requestHeaders, IReadOnlyCollection<Tuple<string, string>> headers)
        {
            if (headers.Count == 0) return;
            foreach (var header in headers)
            {
                requestHeaders.TryAddWithoutValidation(header.Item1, header.Item2);
            }
        }
        private static void DictionaryHeaderConfiguration(HttpRequestHeaders requestHeaders, IReadOnlyDictionary<string, string> headers)
        {
            if (headers.Count == 0) return;
            foreach (var header in headers)
            {
                requestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        private static Task<string> ProcessRequest(HttpRequestMessage request, Action<HttpRequestHeaders> headerConfiguration)
        {
            headerConfiguration?.Invoke(request.Headers);
            return ProcessRequest(request);
        }
        private static Task<string> ProcessRequest(HttpRequestMessage request, Action<HttpRequestHeaders, HttpContentHeaders> headerConfiguration)
        {
            headerConfiguration?.Invoke(request.Headers, request.Content.Headers);
            return ProcessRequest(request);
        }
        private static async Task<string> ProcessRequest(HttpRequestMessage request)
        {
            using (var response = await InternalHttpClient.SendAsync(request))
            using (var content = response.Content)
            {
                var result = await content.ReadAsStringAsync();
                if(!response.IsSuccessStatusCode)
                    throw new Exception($"{response.StatusCode} : {result}");
                return result;
            }
        }
    }
}
