using Acedemy.API.Models.Dto;
using Acedemy.Mvc.UI.Models;
using Newtonsoft.Json;
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
        public async Task<InstructorDto> Get(string accessToken, string path, LoginUserModel userModal)
        {
            InstructorDto ınstructorDto = new InstructorDto();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(path, userModal);
            if (response.IsSuccessStatusCode)
            {
                ınstructorDto = JsonConvert.DeserializeObject<InstructorDto>(await response.Content.ReadAsStringAsync());
                return ınstructorDto;
            }
            else
            {
                ınstructorDto = null;
            }
            return ınstructorDto;
        }


    }
}