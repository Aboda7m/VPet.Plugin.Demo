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

        // Respond to user input by sending a request to the OpenAI API
        public override async void Responded(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return;
            }

            DisplayThink();

            string apiUrl = Plugin.ApiUrl;
            string apiKey = Plugin.ApiKey;

            if (string.IsNullOrEmpty(apiUrl) || string.IsNullOrEmpty(apiKey))
            {
                DisplayThinkToSayRnd("Please configure the API URL and Key in settings.");
                return;
            }

            try
            {
                // Request data with model and user input
                var requestData = new
                {
                    model = "Mirai:latest",  // Use the Mirai model or any other desired model
                    messages = new[] { new { role = "user", content } }
                };

                var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, apiUrl)
                {
                    Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
                };
                requestMessage.Headers.Add("Authorization", $"Bearer {apiKey}");

                // Send the request
                var response = await client.SendAsync(requestMessage);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseContent);
                    string reply = responseObject.choices[0].message.content;

                    // Display the reply in the chat window
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

        // Display the response in the VPet UI
       

        public override void Setting()
        {
            Plugin.Setting();
        }
    }
}
