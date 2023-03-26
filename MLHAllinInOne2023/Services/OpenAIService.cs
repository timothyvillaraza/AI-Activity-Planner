using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.ObjectPool;
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
            List<OpenAIBody> msgs = new List<OpenAIBody>();
            OpenAIBody body = new OpenAIBody();
            body.role = "system";
            body.content = "Life Discussion";
            OpenAIBody body2 = new OpenAIBody();
            body2.role = "system";
            body2.content = prompt;
            msgs.Add(body);
            msgs.Add(body2);

            var model = new
            {
                model = "gpt-3.5-turbo",
                messages = msgs
            };

            // var apiKey = _configuration.GetValue<string>("OpenAI:ApiKey");  // TODO: Setup Config File
            var apiKey = "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";

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

            var requestJson = JsonConvert.SerializeObject(model);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            response.EnsureSuccessStatusCode();
            

            var responseJson = await response.Content.ReadAsStringAsync();
            var openaiResponse = JsonConvert.DeserializeObject<OpenAIResponse>(responseJson);

            return openaiResponse;
        }
    }

    public class OpenAIRequest
    {
        public string model { get; set; }
        public string prompt { get; set; }
    }

    public class OpenAIBody
    {
        public string role { get; set; }
        public string content { get; set; }
    }
    public class OpenAIResponse
    {
        public IEnumerable<OpenAIResponseChoices> choices { get; set; }

        public class OpenAIResponseChoices
        { 
        
            public OpenAIBody message { get; set; }
            public string index { get; set; }
            public string finish_reason { get; set; }

        }
    }
}