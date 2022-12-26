using System.Net;
using System.Text;
using System.Web;

namespace MsBot.Infrastructure;


/// <summary>
/// 请求辅助
/// </summary>
public class RequestHelper
{
    private static RequestHelper _instance;

    private RequestHelper()
    {
    }

    /// <summary>
    /// 实例
    /// </summary>
    public static RequestHelper Instance => _instance ??= new RequestHelper();

    /// <summary>
    /// 请求
    /// </summary>
    /// <param name="url">请求地址</param>
    /// <param name="method">Http Method</param>
    /// <param name="timeOut">超时时间</param>
    /// <param name="contentType">内容类型</param>
    /// <param name="parameter">参数</param>
    /// <param name="headers">Http头</param>
    /// <param name="cookies">Cookies</param>
    public string WebRequest(string url, string method = "GET", int? timeOut = null,
        string contentType = "application/json", object parameter = null,
        IDictionary<string, object> headers = null, params Cookie[] cookies)
    {
        if (string.IsNullOrEmpty(url))
        {
            return null;
        }

        HttpWebRequest req = null;
        HttpWebResponse rsp = null;
        string rspText = null;
        try
        {
            if ((method.ToUpper() == "GET" || method.ToUpper() == "DELETE") && parameter != null)
            {
                if (parameter is Dictionary<string, string> urlDic)
                {
                    url = GetRequestUrl(url, urlDic);
                }
                else
                {
                    urlDic = ObjectHelper.Instance.GetDynamicObjectValues(parameter);
                    if (urlDic != null)
                    {
                        url = GetRequestUrl(url, urlDic);
                    }
                }
            }

            req = (HttpWebRequest)System.Net.WebRequest.Create(url);
            req.Method = method.ToUpper();
            req.AllowAutoRedirect = false;
            if (headers != null && headers.Count > 0)
            {
                foreach (var item in headers)
                {
                    var k = item.Key;
                    switch (k.ToLower())
                    {
                        case "user-agent":
                            req.UserAgent = item.Value.ToString();
                            break;
                        case "referer":
                            req.Referer = item.Value.ToString();
                            break;
                        case "content-type":
                            req.ContentType = item.Value.ToString();
                            break;
                        default:
                            req.Headers.Add(k, item.Value.ToString());
                            break;
                    }
                }
            }

            if (cookies != null && cookies.Length > 0)
            {
                foreach (var ck in cookies)
                {
                    req.CookieContainer.Add(ck);
                }
            }

            if (timeOut != null && timeOut.Value > 0)
            {
                req.Timeout = timeOut.Value;
            }

            if (req.Method == "POST" && parameter != null)
            {
                if (contentType != null)
                {
                    req.ContentType = contentType;
                    if (contentType.ToLower() == "application/json")
                    {
                        if (parameter is string postStringData)
                        {
                            var postBytes = Encoding.UTF8.GetBytes(postStringData);
                            req.ContentLength = postBytes.Length;
                            var rs = req.GetRequestStream();
                            rs.Write(postBytes, 0, postBytes.Length);
                        }
                        else
                        {
                            var jsonStr = SerializerHelper.Instance.JsonSerialize(parameter);
                            var postBytes = Encoding.UTF8.GetBytes(jsonStr);
                            req.ContentLength = postBytes.Length;
                            var rs = req.GetRequestStream();
                            rs.Write(postBytes, 0, postBytes.Length);
                        }
                    }
                    else if (contentType == "application/x-www-form-urlencoded")
                    {
                        if (parameter is Dictionary<string, string> postDic)
                        {
                            SetRequestSteam(req, postDic);
                        }
                        else
                        {
                            postDic = ObjectHelper.Instance.GetDynamicObjectValues(parameter);
                            if (postDic != null)
                            {
                                SetRequestSteam(req, postDic);
                            }
                        }
                    }
                }
            }

            rsp = (HttpWebResponse)req.GetResponse();
            var responseStream = rsp.GetResponseStream();
            var streamReader =
                new StreamReader(responseStream ?? throw new InvalidOperationException(), Encoding.UTF8);
            if (rsp.StatusCode == HttpStatusCode.OK)
            {
                rspText = streamReader.ReadToEnd();
            }

            streamReader.Close();
            responseStream.Close();
            req.Abort();
            rsp.Close();
        }
        catch
        {
            req?.Abort();
            rsp?.Close();
        }

        return rspText;
    }

    private void SetRequestSteam(HttpWebRequest req, Dictionary<string, string> postDic)
    {
        var postList = postDic.Select(f => f.Key + "=" + HttpUtility.UrlEncode(f.Value, Encoding.UTF8)).ToList();
        var postData = string.Join("&", postList);
        var postBytes = Encoding.UTF8.GetBytes(postData);
        req.ContentLength = postBytes.Length;
        var rs = req.GetRequestStream();
        rs.Write(postBytes, 0, postBytes.Length);
    }

    private string GetRequestUrl(string url, Dictionary<string, string> urlDic)
    {
        var parameterList = urlDic.Select(f => f.Key + "=" + HttpUtility.UrlEncode(f.Value, Encoding.UTF8))
            .ToList();
        var queryString = string.Join("&", parameterList);
        return url.Contains('?') ? url + "&" + queryString : url + "?" + queryString;
    }

    /// <summary>
    /// 下载文件
    /// </summary>
    /// <param name="url">下载地址</param>
    /// <param name="savePath">保存路径</param>
    /// <param name="fileName">文件名</param>
    public void DownloadFile(string url, string savePath, string fileName)
    {
        if (string.IsNullOrEmpty(url))
            return;

        HttpWebRequest req = null;
        HttpWebResponse rsp = null;
        try
        {
            req = (HttpWebRequest)System.Net.WebRequest.Create(url);
            req.Method = "GET";
            req.AllowAutoRedirect = false;
            rsp = (HttpWebResponse)req.GetResponse();
            var responseStream = rsp.GetResponseStream();
            if (responseStream == null)
                throw new InvalidOperationException();

            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            var newFileName = Path.Combine(savePath, fileName);

            using (var fs = new FileStream(newFileName, FileMode.Create, FileAccess.Write))
            {
                responseStream.CopyTo(fs);
            }

            responseStream.Close();
            req.Abort();
            rsp.Close();
        }
        catch (Exception ex)
        {
            if (req != null)
                req.Abort();
            if (rsp != null)
                rsp.Close();
        }

        return;
    }
}