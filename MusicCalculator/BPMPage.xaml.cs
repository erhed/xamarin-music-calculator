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

            BPM_Entry.TextChanged += (s, e) =>
            {
                if (e.NewTextValue.Length > 0)
                {
                    double enteredBPM = Convert.ToDouble(e.NewTextValue);
                    if (enteredBPM > 30)
                    {
                        Go_to_TimeIntervals.IsEnabled = true;
                    }
                    else
                    {
                        Go_to_TimeIntervals.IsEnabled = false;
                    }
                }
                else
                {
                    Go_to_TimeIntervals.IsEnabled = false;
                }
            };
        }

        private void Navigate_to_TimeIntervalsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TimeIntervalsPage(bpmResult));
        }

        private void Tap_Button_Clicked(object sender, EventArgs e)
        {
            TempoTap();
        }

        private void TempoTap()
        {
            if (prevTime == 0)
            {
                prevTime = GetTime();                BPM_Entry.Text = "-";            }
            else if ((GetTime() - prevTime) > 2200)
            {
                Reset();
                Go_to_TimeIntervals.IsEnabled = false;
            }
            else
            {
                currentTime = GetTime();
                timeDifference = currentTime - prevTime;
                prevTime = currentTime;
                bpm = 60.0 / timeDifference;
                bpmTotal += bpm;
                countClicks += 1;
                bpmResult = (bpmTotal / countClicks) * 1000;
                BPM_Entry.Text = bpmResult.ToString("0.0");
                Go_to_TimeIntervals.IsEnabled = true;

                System.Diagnostics.Debug.WriteLine(prevTime);
                System.Diagnostics.Debug.WriteLine(currentTime);
                System.Diagnostics.Debug.WriteLine(timeDifference);
                System.Diagnostics.Debug.WriteLine(bpm);
                System.Diagnostics.Debug.WriteLine(bpmTotal);
                System.Diagnostics.Debug.WriteLine(countClicks);
                System.Diagnostics.Debug.WriteLine(bpmResult);
            }
        }

        private void Reset()
        {
            prevTime = 0;
            bpm = 0;
            bpmTotal = 0;
            bpmResult = 0;
            countClicks = 0;
            BPM_Entry.Text = "-";
        }

        private long GetTime()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }
    }
}
