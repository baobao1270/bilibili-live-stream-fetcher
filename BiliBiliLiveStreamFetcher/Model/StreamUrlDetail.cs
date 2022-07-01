namespace BiliBiliLiveStreamFetcher.Model
{
    internal class StreamUrlDetail
    {
        public string Origin { get; set; }

        public string Path { get; set; }

        public string Query { get; set; }

        public string FullUrl => $"{Origin}{Path}{Query}";

        public string QualityName { get; set; }

        public string Codec { get; set; }
    }
}
