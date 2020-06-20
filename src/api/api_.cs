using System;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace IGTOOLS
{

    public class Api_
    {
        public static string xcsrftoken;
        public static string cookies;

        public static async Task<bool> CheckKuki(string kuki)
        {

            // get csrftoken 
            MatchCollection mc = Regex.Matches(kuki, @"(?<=csrftoken\=)[A-Za-z0-9]*");
            if (mc.Count() != 0)
            {

                Api_.xcsrftoken = mc[0].ToString();
                Api_.cookies = kuki;

                JObject r = await Api_.Requests("POST", "https://www.instagram.com/web/friendships/24983173127/follow/");


                return ((string)r["status"] == "ok") ? true : false;

            }
            else
            {
                return false;
            }


        }

        public static async Task<JObject> getPosts(string id, int j)
        {
            JObject post = await Api_.Requests("GET", "https://www.instagram.com/graphql/query/?query_hash=42323d64886122307be10013ad2dcc44&variables={\"id\":\"" + id + "\",\"first\":" + j + "}");
            return post;

        }

        public static async Task<JObject> coment(string komentar, string id)
        {
            JObject result = await Api_.Requests("POST", $"https://www.instagram.com/web/comments/{id}/add/", $"comment_text={komentar}&replied_to_comment_id=");
            return result;
        }

        public static async Task<JObject> like(string id)
        {
            JObject result = await Api_.Requests("POST", $"https://www.instagram.com/web/likes/{id}/like");
            return result;
        }

        public static async Task<JObject> Requests(string method, string url, string data = null)
        {
            try
            {
                HttpWebRequest ht = (HttpWebRequest)WebRequest.Create(url);

                ht.Method = method;


                ht.Host = "www.instagram.com";
                ht.UserAgent = "Mozilla/5.0 (Linux; Android 7.1.1; SM-J250F) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.87 Mobile Safari/537.36";
                ht.ContentType = "application/x-www-form-urlencoded";
                ht.KeepAlive = true;

                ht.Headers.Add("cookie", Api_.cookies);
                ht.Headers.Add("x-csrftoken", Api_.xcsrftoken);
                ht.Headers.Add("x-requested-with", "XMLHttpRequest");
                ht.Headers.Add("save-data", "on");
                ht.Headers.Add("sec-fetch-site", "same-origin");
                ht.Headers.Add("sec-fetch-mode", "cors");
                ht.Headers.Add("origim", "https://www.instagram.com");
                ht.Headers.Add("accept-encoding", "text, deflate, br");
                ht.Headers.Add("x-instagram-ajax", "KONTOLLLLLLLLLL");


                if (!string.IsNullOrEmpty(data))
                {

                    byte[] byteArrayData = Encoding.UTF8.GetBytes(data);
                    ht.ContentLength = byteArrayData.Length;
                    Stream dataStream = await ht.GetRequestStreamAsync();
                    dataStream.Write(byteArrayData, 0, byteArrayData.Length);
                    dataStream.Close();
                }

                HttpWebResponse response = (HttpWebResponse)await ht.GetResponseAsync();
                StreamReader rs = new StreamReader((Stream)response.GetResponseStream(), Encoding.UTF8);

                string result = rs.ReadToEnd().ToString();

                response.Close();
                rs.Close();

                return JObject.Parse(result);

            }
            catch (Exception E)
            {
                Console.WriteLine(E);
                Toast.MakeText("Koneksi error :)", ToastLength.Long).Show();
                return JObject.Parse("{\"status\": \"gagal\"}");
            }
        }


    }
}