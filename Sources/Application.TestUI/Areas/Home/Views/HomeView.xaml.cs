﻿using System.Windows.Controls;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Views.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.Home.ViewModels;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.Home.Views
{
    /// <summary>
    ///     Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl, IViewMap<HomeViewModel>
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }
}