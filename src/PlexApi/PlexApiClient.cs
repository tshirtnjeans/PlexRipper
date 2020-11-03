using PlexRipper.Domain;
using PlexRipper.PlexApi.Api;
using PlexRipper.PlexApi.Config.Converters;
using RestSharp;
using RestSharp.Serialization.Xml;
using RestSharp.Serializers.SystemTextJson;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlexRipper.PlexApi
{
    public class PlexApiClient : RestClient
    {
        public static JsonSerializerOptions SerializerOptions
        {
            get
            {
                return new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                    Converters = {new LongToDateTime()}
                };
            }
        }

        public PlexApiClient()
        {
            this.UseSystemTextJson();
            this.UseDotNetXmlSerializer();
            this.Timeout = 10000;

            // TODO Ignore all bad SSL certificates based on user option set
        }

        public async Task<T> SendRequestAsync<T>(RestRequest request)
        {
            request = AddHeaders(request);

            var response = await ExecuteAsync<T>(request);
            if (response.IsSuccessful)
            {
                Log.Information($"Request to {request.Resource} was successful!");
                Log.Debug($"Response was: {response.Content}");
            }
            else
            {
                Log.Error(response.ErrorException,
                    $"PlexApi Error: Error on request to {request.Resource} ({response.StatusCode}) - {response.Content}");
            }

            return response.Data;
        }

        public async Task<IRestResponse> SendRequestAsync(RestRequest request)
        {
            request = AddHeaders(request);

            var response = await ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                Log.Information($"Request to {request.Resource} was successful!");
                Log.Debug($"Response was: {response.Content}");
            }
            else
            {
                Log.Error(response.ErrorException,
                    $"PlexApi Error: Error on request to {request.Resource} ({response.StatusCode}) - {response.Content}");
            }

            return response;
        }

        public async Task<byte[]> SendImageRequestAsync(RestRequest request)
        {
            request = AddHeaders(request);

            var response = await ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                Log.Information($"Request to {request.Resource} was successful!");
                Log.Debug($"Response length was: {response.Content.Length}");
            }
            else
            {
                Log.Error(response.ErrorException,
                    $"PlexApi Error: Error on request to {request.Resource} ({response.StatusCode})");
            }

            return response.RawBytes;
        }

        /// <summary>
        /// This will add the necessary headers to the request.
        /// </summary>
        /// <param name="request">The request to change.</param>
        /// <returns>The request with headers added.</returns>
        private RestRequest AddHeaders(RestRequest request)
        {
            foreach (var headerPair in PlexHeaderData.GetBasicHeaders)
            {
                request.AddHeader(headerPair.Key, headerPair.Value);
            }

            return request;
        }
    }
}