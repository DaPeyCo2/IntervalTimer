using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using IntervalTimerApp.Models;
using IntervalTimerApp.Services;

namespace IntervalTimerApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly TemplateService _service = new();

        public ObservableCollection<TimerTemplate> Templates { get; } = new();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Templates.Clear();
            var templates = await _service.LoadTemplatesAsync();
            foreach (var t in templates)
                Templates.Add(t);
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditTemplatePage(_service));
        }

        private async void OnTemplateSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is TimerTemplate template)
            {
                await Navigation.PushAsync(new TimerPage(template));
            }
        }
    }
}
