using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Services
{
    public class CategoryService
    {
        private readonly HttpClient _http = new HttpClient();
        public async Task<List<Category>> GetAll()
        {
            var response = await _http.GetStringAsync($"{AppConfig.ApiBaseUrl}category");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<ApiResponse<List<Category>>>(response, options);
            return result.Data;
        }
    }
}
