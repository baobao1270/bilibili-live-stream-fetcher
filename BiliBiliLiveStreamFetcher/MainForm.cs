using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BiliBiliLiveStreamFetcher.Model;
using BiliBiliLiveStreamFetcher.Properties;
using Flurl;
using Flurl.Http;

namespace BiliBiliLiveStreamFetcher
{
    public partial class MainForm : Form
    {
        private readonly string mpvPath;

        public MainForm()
        {
            InitializeComponent();
            ListViewStreamUrls.Columns.Add("画质", 60);
            ListViewStreamUrls.Columns.Add("编码", 60);
            ListViewStreamUrls.Columns.Add("格式", 60);
            ListViewStreamUrls.Columns.Add("URL", 521);
            WebBrowserInstruction.DocumentText = Resources.Instruction;
            mpvPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "mpv.exe");
            if (!File.Exists(mpvPath)) {
                File.WriteAllBytes(mpvPath, Resources.MPVPlayer);
            }
        }

        private async void ButtonParse_Click(object sender, EventArgs e)
        {
            ProgressBarHttpRequest.Value = 0;
            var streamUrls = new List<StreamUrlDetail>();
            try
            {
                var roomId = GetRoomIdByText(TextBoxRoomIdUrl.Text.Trim());
                ProgressBarHttpRequest.Value = 50;
                streamUrls.AddRange(await GetStreamUrlDetailByRoomId(roomId));
                ProgressBarHttpRequest.Value = 60;
                streamUrls.AddRange(await GetStreamUrlDetailByRoomId(roomId, 20000));
                ProgressBarHttpRequest.Value = 70;
                streamUrls.AddRange(await GetStreamUrlDetailByRoomId(roomId, 30000));
                ProgressBarHttpRequest.Value = 80;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ProgressBarHttpRequest.Value = 0;
                return;
            }
            if (streamUrls.Count <= 0)
            {
                MessageBox.Show("服务器没有返回任何直播流，可能的原因有：直播未开始、已加密、需要付费、编码错误，或清晰度低于 720P。");
                ProgressBarHttpRequest.Value = 0;
                return;
            }
            ProgressBarHttpRequest.Value = 100;
            UpdateListViewStreamUrls(streamUrls);
        }

        private int GetRoomIdByText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new Exception("直播间地址不能为空");
            }

            if (int.TryParse(text, out var result))
            {
                return result;
            }

            if (text.StartsWith("https://live.bilibili.com/"))
            {
                return int.Parse(new Uri(text).AbsolutePath.Substring(1).Trim());
            }

            throw new Exception("无法解析直播间链接");
        }

        private void UpdateListViewStreamUrls(IEnumerable<StreamUrlDetail> streamUrls)
        {
            ListViewStreamUrls.BeginUpdate();
            ListViewStreamUrls.Items.Clear();
            streamUrls.ToList().ForEach(url =>
            {
                var list = new ListViewItem{ Text = url.QualityName };
                list.SubItems.Add(url.Codec);
                list.SubItems.Add(Path.GetExtension(new Uri(url.FullUrl).AbsolutePath));
                list.SubItems.Add(url.FullUrl);                
                ListViewStreamUrls.Items.Add(list);
            });
            ListViewStreamUrls.EndUpdate();
        }

        private async Task<IEnumerable<StreamUrlDetail>> GetStreamUrlDetailByRoomId(int roomId, int qn = 10000)
        {
            var response = await new Uri("https://api.live.bilibili.com/xlive/web-room/v2/index/getRoomPlayInfo")
                .SetQueryParams(new
                {
                    room_id = roomId,
                    qn = qn,
                    protocol = "0,1",
                    format = "0,1,2",
                    codec = "0,1",
                    platform = "web",
                    ptype = 8
                }).GetJsonAsync<ApiResponse<RoomPlayInfo>>();
            if (response.Code != 0) throw new Exception($"请求视频直播流数据失败：错误码 {response.Code}");
            var urls = new List<StreamUrlDetail>();
            var streamUrlDetails = new List<StreamUrlDetail>();
            var qualityNames = new Dictionary<int, string>()
            {
                {10000, "原画"}, {20000, "4K"}, {30000, "杜比"}
            };
            response.Data?.PlayurlInfo?.PlayUrl?.Streams?
                .ToList().FindAll(x => true)?.ForEach(stream =>
                {
                    stream.Formats?
                    .FirstOrDefault()?.Codecs?
                    .ToList().FindAll(x => x.CurrentQn == qn || x.CurrentQn < 10000)?.ForEach(codec =>
                    {
                        codec.UrlInfos?.ToList().ForEach(urlInfo =>
                        {
                            streamUrlDetails.Add(new StreamUrlDetail
                            {
                                QualityName = qualityNames.TryGetValue(codec.CurrentQn, out var qualityName) ? qualityName : $"低清 ({codec.CurrentQn})",
                                Codec = codec.CodecName,
                                Origin = urlInfo.Host,
                                Path = codec.BaseUrl,
                                Query = urlInfo.Extra
                            });
                        });
                    });
                });                
            return streamUrlDetails;
        }

        private void ButtonFillUrlLuotianyi_Click(object sender, EventArgs e) => TextBoxRoomIdUrl.Text = "https://live.bilibili.com/1546736";
        private void ButtonFillUrlTest_Click(object sender, EventArgs e) => TextBoxRoomIdUrl.Text = "https://live.bilibili.com/14047";
        private void ButtonFillUrDev_Click(object sender, EventArgs e) => TextBoxRoomIdUrl.Text = "https://live.bilibili.com/25440";

        private string GetSelectedUrl()
        {
            if (ListViewStreamUrls.SelectedItems.Count != 1)
            {
                MessageBox.Show("您尚未选择一个直播流地址，或选择了多个直播流地址。\n请选择并仅选择一个直播流地址。");
                return null;
            }

            var subitems = ListViewStreamUrls.SelectedItems[0].SubItems;
            return subitems[subitems.Count - 1].Text;
        }

        private void ButtonCopyUrl_Click(object sender, EventArgs e)
        {
            var url = GetSelectedUrl();
            if (string.IsNullOrEmpty(url)) return;
            Clipboard.SetDataObject(url);
            MessageBox.Show("已复制\n\n请打开 VLC——媒体——打开网络串流，然后粘贴，然后点击播放。\n\n注意：B 站可能限制最长串流时间为 1 小时，1 小时后可能会直播中断。");
        }

        private void ButtonOpenUrl_Click(object sender, EventArgs e)
        {
            var roomId = GetRoomIdByText(TextBoxRoomIdUrl.Text.Trim());
            var referrer = $"https://live.bilibili.com/{roomId}";
            var url = GetSelectedUrl();
            if (string.IsNullOrEmpty(url)) return;
            ;
            System.Diagnostics.Process.Start(mpvPath, string.Join(" ", new string[]
            {
                "--user-agent=\"Mozilla/5.0 (Macintosh; Intel Mac OS X 12_2_1) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.3 Safari/605.1.15\"",
                $"--referrer=https://live.bilibili.com/{roomId}",
                $"\"{url}\""
            }));
        }
    }
}
