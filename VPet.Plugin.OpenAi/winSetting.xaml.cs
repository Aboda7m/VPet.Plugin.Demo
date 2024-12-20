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
            tbModelName.Text = plugin.ModelName;  // Pre-fill the current Model Name
        }

        // Save Button Click Handler
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string apiUrl = tbAPIURL.Text;
            string apiKey = tbAPIKey.Text;
            string modelName = tbModelName.Text;

            if (string.IsNullOrWhiteSpace(apiUrl) || string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(modelName))
            {
                MessageBox.Show("API URL, API Key, and Model Name must be provided!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Set the API URL, Key, and Model Name in the plugin
            plugin.ApiUrl = apiUrl;
            plugin.ApiKey = apiKey;
            plugin.ModelName = modelName;  // Set the model name

            // Save the settings (persist in plugin)
            plugin.Save();

            MessageBox.Show("Settings saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
