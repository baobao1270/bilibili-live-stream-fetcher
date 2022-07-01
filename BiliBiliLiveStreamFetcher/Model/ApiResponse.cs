using Newtonsoft.Json;

namespace BiliBiliLiveStreamFetcher.Model
{
    internal class ApiResponse<T> where T : class
    {
        [JsonProperty("code")]
        public int? Code { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
