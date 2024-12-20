using LinePutScript;
using System;
using System.Windows;
using System.Windows.Controls;
using VPet_Simulator.Windows.Interface;

namespace VPet.Plugin.OpenAiPlugin
{
    public class OpenAiPlugin : MainPlugin
    {
        public OpenAiPlugin(IMainWindow mainwin) : base(mainwin) { }

        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }

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
        }

        public override void Setting()
        {
            // Open settings window for configuring the API URL and Key
            new winSetting(this).ShowDialog();
        }

        public override string PluginName => "OpenAiPlugin";
    }
}
