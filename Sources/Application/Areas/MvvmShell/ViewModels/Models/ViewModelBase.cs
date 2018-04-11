﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models
{
    public abstract class ViewModelBase : IViewModel, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}