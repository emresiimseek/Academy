using Acedemy.API.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Acedemy.Mvc.UI.ApiServices
{
    public class UserApiService
    {
        private HttpClient _httpClient { get; set; }
        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        

        public async Task Add(InstructorDto ınstructorDto, string path)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
                path, ınstructorDto);
            response.EnsureSuccessStatusCode();
        }
    }
}