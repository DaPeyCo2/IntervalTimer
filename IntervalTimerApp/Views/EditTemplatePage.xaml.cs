using Microsoft.Maui.Controls;
using IntervalTimerApp.Models;
using IntervalTimerApp.Services;
using System;
using System.Linq;

namespace IntervalTimerApp.Views
{
    public partial class EditTemplatePage : ContentPage
    {
        private readonly TemplateService _service;

        public EditTemplatePage(TemplateService service)
        {
            InitializeComponent();
            _service = service;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var template = new TimerTemplate
            {
                Name = NameEntry.Text ?? string.Empty,
                Repetitions = int.TryParse(RepetitionEntry.Text, out var rep) ? rep : 1,
                Intervals = IntervalsEntry.Text?.Split(',').Select(s => new TimerInterval { Seconds = int.Parse(s.Trim()) }).ToList() ?? new()
            };

            var templates = await _service.LoadTemplatesAsync();
            templates.Add(template);
            await _service.SaveTemplatesAsync(templates);
            await Navigation.PopAsync();
        }
    }
}
