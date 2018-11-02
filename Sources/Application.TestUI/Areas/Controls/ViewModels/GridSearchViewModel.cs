using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.Commands;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfExtensions.Areas.MvvmShell.ViewModels.Models;
using Mmu.Mlh.WpfExtensions.TestUI.Areas.Controls.ViewData;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.Controls.ViewModels
{
    public class GridSearchViewModel : ViewModelBase, IMainNavigationViewModel, IViewModelWithHeading, IInitializableViewModel
    {
        private ObservableCollection<IndividualViewData> _individualList;
        private string _text = string.Empty;

        public ICommand DoIt
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        _individualList.Add(new IndividualViewData("Hans", new DateTime(1999, 01, 01), 175));
                    });
            }
        }

        public string HeadingText { get; } = "Grid Search";
        public ICollectionView Individuals { get; private set; }
        public string NavigationDescription { get; } = "Grid Search";
        public int NavigationSequence { get; } = 3;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                Individuals.Refresh();
            }
        }

        public Task InitializeAsync()
        {
            _individualList = IndividualViewData.CreateSome();
            Individuals = CollectionViewSource.GetDefaultView(_individualList);
            Individuals.Filter = item => FilterIndividual((IndividualViewData)item);

            return Task.CompletedTask;
        }

        private bool FilterIndividual(IndividualViewData individual)
        {
            return individual.FirstName.Contains(Text)
                || individual.Height.ToString().Contains(Text)
                || individual.Birthdate.ToString(CultureInfo.CurrentCulture).Contains(Text);
        }
    }
}