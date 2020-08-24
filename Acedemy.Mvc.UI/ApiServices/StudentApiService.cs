using Acedemy.API.Models.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Acedemy.Mvc.UI.ApiService
{
    public class StudentApiService
    {
        private HttpClient _httpClient { get; set; }
        public StudentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<StudentDto>> GetAllAsync(string path ,string accessToken)
        {

            List<StudentDto> studentModels = null;
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                studentModels = JsonConvert.DeserializeObject<List<StudentDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                studentModels = null;
            }
            return studentModels;
        }

    }
}