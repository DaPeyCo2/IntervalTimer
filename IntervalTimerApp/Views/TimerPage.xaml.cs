using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.Threading;
using IntervalTimerApp.Models;
using Microsoft.Maui.Essentials;

namespace IntervalTimerApp.Views
{
    public partial class TimerPage : ContentPage
    {
        private readonly TimerTemplate _template;
        private int _currentIntervalIndex;
        private int _currentRepetition;
        private CancellationTokenSource? _cts;

        public TimerPage(TimerTemplate template)
        {
            InitializeComponent();
            _template = template;
        }

        private async void OnStartClicked(object sender, EventArgs e)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            _currentIntervalIndex = 0;
            _currentRepetition = 0;
            await RunTimer(_cts.Token);
        }

        private async Task RunTimer(CancellationToken token)
        {
            while (_currentRepetition < _template.Repetitions)
            {
                var interval = _template.Intervals[_currentIntervalIndex];
                for (int i = interval.Seconds; i >= 0; i--)
                {
                    TimerLabel.Text = TimeSpan.FromSeconds(i).ToString();
                    if (i <= 3 && i > 0)
                    {
                        // Play beep here (placeholder)
                        try { Vibration.Vibrate(TimeSpan.FromMilliseconds(200)); } catch { }
                    }
                    await Task.Delay(1000, token);
                    if (token.IsCancellationRequested) return;
                }
                _currentIntervalIndex++;
                if (_currentIntervalIndex >= _template.Intervals.Count)
                {
                    _currentIntervalIndex = 0;
                    _currentRepetition++;
                }
            }
            await DisplayAlert("Done", "Timer complete", "OK");
        }
    }
}
