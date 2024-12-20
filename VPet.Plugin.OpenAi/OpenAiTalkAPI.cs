using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VPet_Simulator.Windows.Interface;

namespace VPet.Plugin.OpenAiPlugin
{
    public class OpenAiTalkAPI : TalkBox
    {
        public OpenAiTalkAPI(OpenAiPlugin mainPlugin) : base(mainPlugin)
        {
            Plugin = mainPlugin;
        }

        protected OpenAiPlugin Plugin;

        public override string APIName => "OpenAiPlugin";

        private static readonly HttpClient client = new HttpClient();

        public override async void Responded(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return;
            }

            DisplayThink();

            // Retrieve API URL and key from settings
            string apiUrl = Plugin.ApiUrl;
            string apiKey = Plugin.ApiKey;

            if (string.IsNullOrEmpty(apiUrl) || string.IsNullOrEmpty(apiKey))
            {
                DisplayThinkToSayRnd("Please configure the API URL and Key in settings.");
                return;
            }

            try
            {
                // Create the request data
                var requestData = new
                {
                    model = "gpt-3.5-turbo",  // Use the appropriate model
                    messages = new[] { new { role = "user", content } }
                };

                var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, apiUrl)
                {
                    Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
                };
                requestMessage.Headers.Add("Authorization", $"Bearer {apiKey}");

                // Make the request
                var response = await client.SendAsync(requestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseContent);
                    string reply = responseObject.choices[0].message.content;
                    DisplayThinkToSayRnd(reply);
                }
                else
                {
                    DisplayThinkToSayRnd("Error: Could not get response from the API.");
                }
            }
            catch (Exception ex)
            {
                DisplayThinkToSayRnd($"Error occurred: {ex.Message}");
            }
        }

        public override void Setting()
        {
            Plugin.Setting();
        }
    }
}
