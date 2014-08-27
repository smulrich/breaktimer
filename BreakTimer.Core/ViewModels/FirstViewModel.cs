// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the FirstViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using BreakTimer.Core.Models;

namespace BreakTimer.Core.ViewModels
{
    using System.Windows.Input;
    using Cirrious.MvvmCross.ViewModels;

    /// <summary>
    /// Define the FirstViewModel type.
    /// </summary>
    public class FirstViewModel : BaseViewModel
    {
        private string _title = "You Need A Break!";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value, () => Title); }
        }

        private ObservableCollection<DailyBreak> _breaks;
        public ObservableCollection<DailyBreak> Breaks
        {
            get { return _breaks; }
            set
            {
                _breaks = value;
                RaisePropertyChanged(() => Breaks);
            }
        }

        public FirstViewModel()
        {
            Breaks = new ObservableCollection<DailyBreak>
            {
                new DailyBreak{Reason=Reason.Coffee, TimeOfDay=new TimeSpan(8,0,0), Enabled=true},
                new DailyBreak{Reason=Reason.Snack, TimeOfDay=new TimeSpan(10,0,0), Enabled=false},
                new DailyBreak{Reason=Reason.Coffee, TimeOfDay=new TimeSpan(14,0,0), Enabled=true},
                new DailyBreak{Reason=Reason.Stretch, TimeOfDay=new TimeSpan(15,30,0), Enabled=true},
            };
        }

        public ICommand ToggleEnabledCommand
        {
            get { return new MvxCommand<DailyBreak>(DoToggleEnabled); }
        }
        public void DoToggleEnabled(DailyBreak b)
        {
            //Not sure if all of this is needed, other than b.Enabled=!b.Enabled
            //I only added the rest in hopes that it would fire a property change in the View.  But it does not seem to work.
            var index = Breaks.IndexOf(b);
            if (index >= 0)
            {
                b.Enabled = !b.Enabled;
                Breaks[index] = b;
            }
        }
    }
}