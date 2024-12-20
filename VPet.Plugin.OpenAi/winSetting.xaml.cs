using System;
using System.Windows;
using VPet.Plugin.OpenAiPlugin;

namespace VPet.Plugin.OpenAiPlugin
{
    public partial class winSetting : Window
    {
        private OpenAiPlugin plugin;

        // Constructor to accept the plugin object
        public winSetting(OpenAiPlugin plugin)
        {
            InitializeComponent();
            Resources = Application.Current.Resources;

            this.plugin = plugin;
            tbAPIURL.Text = plugin.ApiUrl;  // Pre-fill the current API URL
            tbAPIKey.Text = plugin.ApiKey;  // Pre-fill the current API key
        }

        // Save Button Click Handler
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string apiUrl = tbAPIURL.Text;
            string apiKey = tbAPIKey.Text;

            if (string.IsNullOrWhiteSpace(apiUrl) || string.IsNullOrWhiteSpace(apiKey))
            {
                MessageBox.Show("Both API URL and API Key must be provided!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Set the API URL and Key in the plugin
            plugin.ApiUrl = apiUrl;
            plugin.ApiKey = apiKey;

            // Save the settings (persist in plugin)
            plugin.Save();

            MessageBox.Show("Settings saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
