using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dcgx
{
    public class Stuff
    {

        public static int quantity = 0;
        public static string folderPath = Environment.CurrentDirectory + "\\results.txt";
        public static string DiscordActivationURL = "https://discord.com/billing/partner-promotions/1180231712274387115/";


        public static async Task SendPostRequest()
        {
            var url = "https://api.discord.gx.games/v1/direct-fulfillment";
            var jsonData = "{\"partnerUserId\":\"a33864d3f487501951f7bdcda70561b5bfa38baae510a85062b2c93e22125c5d\"}";

            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("authority", "api.discord.gx.games");
                request.Headers.Add("accept", "*/*");
                request.Headers.Add("accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("origin", "https://www.opera.com");
                request.Headers.Add("referer", "https://www.opera.com/");
                request.Headers.Add("sec-ch-ua", "\"Opera GX\";v=\"105\", \"Chromium\";v=\"119\", \"Not?A_Brand\";v=\"24\"");
                request.Headers.Add("sec-ch-ua-mobile", "?0");
                request.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
                request.Headers.Add("sec-fetch-dest", "empty");
                request.Headers.Add("sec-fetch-mode", "cors");
                request.Headers.Add("sec-fetch-site", "cross-site");
                request.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36 OPR/105.0.0.0");

                request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    JObject json = JObject.Parse(result);

                    string tokenValue = json["token"].ToString();
                    quantity++;
                    string finalLink = DiscordActivationURL + tokenValue;
                    Stuff.Save(finalLink);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }


        }

        public static void Save(String url)
        {
            using (StreamWriter sw = new StreamWriter(folderPath, true))
            {
                sw.WriteLine(url);
            }

        }
    }
}
