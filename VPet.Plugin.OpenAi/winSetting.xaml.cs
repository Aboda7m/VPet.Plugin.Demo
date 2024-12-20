using LinePutScript.Localization.WPF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;

namespace VPet.Plugin.OpenAiPlugin
{
    /// <summary>
    /// winSetting.xaml 的交互逻辑
    /// </summary>
    public partial class winSetting : Window
    {
        public winSetting()
        {
            InitializeComponent();
            Resources = Application.Current.Resources;
        }

        public winSetting(OpenAiPlugin plugin)
        {
            InitializeComponent();
            Resources = Application.Current.Resources;
            // Other initialization logic using the plugin parameter can go here.
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // This method would handle saving settings.
            // Placeholder for actual implementation if needed.
            this.Close();
        }
    }
}
