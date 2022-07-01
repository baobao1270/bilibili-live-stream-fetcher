using Newtonsoft.Json;
using System;

namespace BiliBiliLiveStreamFetcher.Model
{
    internal class RoomPlayInfo
    {
        [JsonProperty("playurl_info")]
        public PlayUrlInfo PlayurlInfo { get; set; }

        public class PlayUrlInfo
        {
            [JsonProperty("playurl")]
            public PlayUrl PlayUrl { get; set; }
        }

        public class PlayUrl
        {
            [JsonProperty("stream")]
            public StreamItem[] Streams { get; set; }
        }

        public class StreamItem
        {
            [JsonProperty("protocol_name")]
            public string ProtocolName { get; set; } = string.Empty;

            [JsonProperty("format")]
            public FormatItem[] Formats { get; set; }
        }

        public class FormatItem
        {
            [JsonProperty("codec")]
            public CodecItem[] Codecs { get; set; }
        }

        public class CodecItem
        {
            [JsonProperty("codec_name")]
            public string CodecName { get; set; } = string.Empty;

            [JsonProperty("base_url")]
            public string BaseUrl { get; set; } = string.Empty;

            [JsonProperty("current_qn")]
            public int CurrentQn { get; set; }

            [JsonProperty("url_info")]
            public UrlInfoItem[] UrlInfos { get; set; }
        }

        public class UrlInfoItem
        {
            [JsonProperty("host")]
            public string Host { get; set; } = string.Empty;

            [JsonProperty("extra")]
            public string Extra { get; set; } = string.Empty;
        }
    }
}
