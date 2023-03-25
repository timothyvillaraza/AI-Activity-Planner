using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MLHAllinInOne2023.Services
{
    public interface IOpenAIService
    {
        Task<OpenAIResponse> GenerateText(string prompt);
    }

    public class OpenAIService : IOpenAIService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public OpenAIService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<OpenAIResponse> GenerateText(string prompt)
        {
            var model = new OpenAIRequest
            {
                Model = "text-davinci-002",
                Prompt = prompt,
                Temperature = 0.5,
                MaxTokens = 60,
                TopP = 1,
                FrequencyPenalty = 0,
                PresencePenalty = 0
            };

            // var apiKey = _configuration.GetValue<string>("OpenAI:ApiKey");  // TODO: Setup Config File
            var apiKey = "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";
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

            var requestJson = JsonConvert.SerializeObject(model);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/engines/davinci-codex/completions", content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            var openaiResponse = JsonConvert.DeserializeObject<OpenAIResponse>(responseJson);
            return openaiResponse;
        }
    }

    public class OpenAIRequest
    {
        public string Model { get; set; }
        public string Prompt { get; set; }
        public double Temperature { get; set; }
        public int MaxTokens { get; set; }
        public double TopP { get; set; }
        public double FrequencyPenalty { get; set; }
        public double PresencePenalty { get; set; }
    }

    public class OpenAIResponse
    {
        public string Text { get; set; }
        public string Choices { get; set; }
    }
}