using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MusicCalculator
{
    public partial class BPMPage : ContentPage
    {
        long prevTime;
        int countClicks;
        long currentTime;
        double bpm;
        long timeDifference;
        double bpmTotal;
        double bpmResult;
        
        public BPMPage()
        {
            InitializeComponent();

            Title = "BPM";
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#233951");
        }

        private void Navigate_to_TimeIntervalsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TimeIntervalsPage());
        }

        private void Tap_Button_Clicked(object sender, EventArgs e)
        {
            TempoTap();
        }

        private void TempoTap()
        {
            if (prevTime == 0)
            {
                prevTime = GetTime();            }
            else if ((GetTime() - prevTime) > 2200)
            {
                //reset()
            }
            else
            {
                currentTime = GetTime();
                timeDifference = currentTime - prevTime;
                prevTime = currentTime;
                bpm = 60 / timeDifference;
                bpmTotal += bpm;
                countClicks += 1;
                bpmResult = (bpmTotal / countClicks) * 1000;
                //result
            }
        }

        private long GetTime()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }
    }
}
