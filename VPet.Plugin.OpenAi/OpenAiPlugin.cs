using LinePutScript;
using System;
using System.Windows;
using System.Windows.Controls;
using VPet.Plugin.OpenAiPlugin;
using VPet_Simulator.Windows.Interface;

namespace VPet.Plugin.OpenAiPlugin
{
    public class OpenAiPlugin : MainPlugin
    {
        public OpenAiPlugin(IMainWindow mainwin) : base(mainwin) { }

        public string ApiUrl { get; set; } = "http://localhost:3000/api/chat/completions";  // Default value
        public string ApiKey { get; set; } = "sk-2e211c0f69f84cf7b9b5eff42355bdfa"; // Default value
        public string ModelName { get; set; } = "Mirai:latest"; // Default model

        public override void LoadPlugin()
        {
            // Add OpenAiTalkAPI to the list of available talk APIs
            MW.TalkAPI.Add(new OpenAiTalkAPI(this));

            // Add OpenAi plugin option to the toolbar menu
            var menuItem = new MenuItem()
            {
                Header = "OpenAi",
                HorizontalContentAlignment = HorizontalAlignment.Center
            };

            menuItem.Click += (s, e) => { Setting(); }; // Show the settings window when clicked
            MW.Main.ToolBar.MenuMODConfig.Items.Add(menuItem);
        }

        public override void Save()
        {
            // Save the API settings
            MW.Set["OpenAi"][(gstr)"apiUrl"] = ApiUrl;
            MW.Set["OpenAi"][(gstr)"apiKey"] = ApiKey;
            MW.Set["OpenAi"][(gstr)"modelName"] = ModelName; // Save the model name
        }

        public override void Setting()
        {
            // Open settings window for configuring the API URL, Key, and Model
            new winSetting(this).ShowDialog();
        }

        public override string PluginName => "OpenAiPlugin";
    }
}
