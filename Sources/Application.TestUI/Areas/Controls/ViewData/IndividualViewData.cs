using System;
using System.Collections.ObjectModel;

namespace Mmu.Mlh.WpfExtensions.TestUI.Areas.Controls.ViewData
{
    public class IndividualViewData
    {
        public DateTime Birthdate { get; }
        public string FirstName { get; }
        public int Height { get; }

        public IndividualViewData(string firstName, DateTime birthdate, int height)
        {
            FirstName = firstName;
            Birthdate = birthdate;
            Height = height;
        }

        public static ObservableCollection<IndividualViewData> CreateSome()
        {
            return new ObservableCollection<IndividualViewData>
            {
                new IndividualViewData("Matthias", new DateTime(1986, 12, 29), 185),
                new IndividualViewData("Steve", new DateTime(1964, 12, 18), 188),
                new IndividualViewData("Stefanie", new DateTime(2002, 03, 04), 150)
            };
        }
    }
}