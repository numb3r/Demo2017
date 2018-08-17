using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Demo17
{
    public class MainPageViewModel : BindableObject
    {
        private double _circularProgress;

        public MainPageViewModel()
        {
            GetBindings();
            GetModelDatas();
        }


        public ICommand ClippedCmd { get; set; }
        public double CircularProgress
        {
            get => _circularProgress;
            set
            {
                _circularProgress = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Sheet> Sheets { get; set; }

        private void GetModelDatas()
        {
            Sheets = new ObservableCollection<Sheet>();
            Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(.01), OnTimer);

            for (var i = 0; i < 5; i++)
            {
                Sheets.Add(new Sheet());
                if (i == 0 && Sheets[i] != null)
                    Sheets[i].IsCurrent = true;
            }
        }


        private bool OnTimer()
        {
            var progress = (CircularProgress + .001);
            if (progress > 0.5) progress = 0;
            CircularProgress = progress;
            return true;
        }

        private void GetBindings()
        {

        }
    }

    public class Sheet : BindableObject
    {
        private bool _isCurrent;

        public bool IsCurrent
        {
            get { return _isCurrent; }
            set
            {
                if (_isCurrent != value)
                {
                    _isCurrent = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}