using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using IntervalTimerApp.Models;
using Microsoft.Maui.Storage;

namespace IntervalTimerApp.Services
{
    public class TemplateService
    {
        private readonly string _filePath;

        public TemplateService()
        {
            _filePath = Path.Combine(FileSystem.AppDataDirectory, "templates.json");
        }

        public async Task<List<TimerTemplate>> LoadTemplatesAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<TimerTemplate>();
            }

            using var stream = File.OpenRead(_filePath);
            return await JsonSerializer.DeserializeAsync<List<TimerTemplate>>(stream) ?? new List<TimerTemplate>();
        }

        public async Task SaveTemplatesAsync(List<TimerTemplate> templates)
        {
            using var stream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(stream, templates, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
