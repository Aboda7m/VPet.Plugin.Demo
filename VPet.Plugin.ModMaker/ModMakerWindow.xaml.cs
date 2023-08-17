﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VPet.Plugin.ModMaker.WinModEdit;

namespace VPet.Plugin.ModMaker;

/// <summary>
/// winModMaker.xaml 的交互逻辑
/// </summary>
public partial class ModMakerWindow : Window
{
    public ModMaker ModMaker { get; set; }
    public ModEditWindow WinModEdit { get; set; }

    public ModMakerWindow()
    {
        InitializeComponent();
    }

    private void Button_CreateNewMod_Click(object sender, RoutedEventArgs e)
    {
        WinModEdit = new();
        WinModEdit.Show();
        this.Hide();
        WinModEdit.Closed += (s, e) =>
        {
            this.Close();
        };
    }
}
