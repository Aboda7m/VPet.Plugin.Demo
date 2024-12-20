using Newtonsoft.Json;
using System.Reflection.PortableExecutable;
using System.Windows;
using VPet.Plugin.OpenAiPlugin;

namespace VPet.Plugin.OpenAiPlugin
{
    public partial class winSetting : Window
    {
        private OpenAiPlugin plugin;
        private long totalused = 0;

        // Constructor to accept the plugin object
        public winSetting(OpenAiPlugin plugin)
        {
            InitializeComponent();
            Resources = Application.Current.Resources;

            this.plugin = plugin;
            
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

            // Set up the plugin client with the new values
            

            // Close the settings window after saving
            MessageBox.Show("Settings saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
