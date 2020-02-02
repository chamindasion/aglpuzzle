using System;
using Agl.Puzzle.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Agl.Puzzle.Data
{
    public class ApiClientBase
    {
        private RestClient _apiClient;

        protected TResult Execute<TResult>(IRestRequest request)
        {
            var response = ApiClient.Execute(request);

            if (response.IsSuccessful)
            {
                if (typeof(TResult) == typeof(bool))
                    return (TResult)Convert.ChangeType(true, typeof(TResult));
                return JsonConvert.DeserializeObject<TResult>(response.Content);
            }
            throw new ApplicationException(response.StatusCode.ToString());
        }

        public static string BaseUrl { get; set; }

        public ApiClientBase(AglConfiguration configuration)
        {
            BaseUrl = configuration.AglAzureDataStore.ApiUrl;
        }

        

        public RestClient ApiClient
        {
            get
            {
                if (_apiClient != null)
                    return _apiClient;

                _apiClient = new RestClient(BaseUrl);
                
                return _apiClient;
            }
        }
    }
}
