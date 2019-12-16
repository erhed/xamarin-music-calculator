using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MusicCalculator
{
    public partial class TimeIntervalsPage : ContentPage
    {
        public TimeIntervalsPage(double bpm)
        {
            InitializeComponent();
            Title = "Time intervals";
            SetIntervals(bpm);
        }

        private void SetIntervals(double bpm)
        {

        }
    }
}
