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
            double msPerBeat = 60000.0 / bpm;

            double twoOne = msPerBeat * 2;
            double oneOne = msPerBeat;
            double oneTwo = msPerBeat / 2;
            double oneFour = msPerBeat / 4;
            double oneEight = msPerBeat / 8;
            double oneTwelve = msPerBeat / 12;
            double oneSixteen = msPerBeat / 16;
            double oneThirtytwo = msPerBeat / 32;
            double oneSixtyfour = msPerBeat / 64;

            Label_BPM.Text = bpm.ToString("0");

            Label_TwoOne.Text = twoOne.ToString("0");
            Label_OneOne.Text = oneOne.ToString("0");
            Label_OneTwo.Text = oneTwo.ToString("0");
            Label_OneFour.Text = oneFour.ToString("0");
            Label_OneEight.Text = oneEight.ToString("0");
            Label_OneTwelve.Text = oneTwelve.ToString("0");
            Label_OneSixteen.Text = oneSixteen.ToString("0");
            Label_OneThirtytwo.Text = oneThirtytwo.ToString("0");
            Label_OneSixtyfour.Text = oneSixtyfour.ToString("0");
        }
    }
}
